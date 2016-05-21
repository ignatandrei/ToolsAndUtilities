using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ComDoneRight
{
    public class ComDisposable : DynamicObject,  IDisposable
    {
        private dynamic _comInstance;
        private Type _typeInstance;
        public ComDisposable(object comInstance):this(comInstance,comInstance.GetType())
        {
           
        }
        protected ComDisposable(object comInstance, Type typeInstance)
        {
            _typeInstance = typeInstance;
            _comInstance = comInstance;

        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            return base.TryGetIndex(binder, indexes, out result);
        }

        public void Dispose()
        {
            try
            {
                Marshal.ReleaseComObject(_comInstance);
            }
            catch (COMException)
            {
                //object probably closed already
            }
            _comInstance = null;
        }

        public ComDisposable this[string id]
        {
            get { return InvokeMethod("Item", new object[1] {id}); }
        }
        public ComDisposable this[int id]
        {
            get { return InvokeMethod("Item", new object[1] { id }); }
        }
        ComDisposable GetMember(string name)
        {
            var prop = _typeInstance.GetProperty(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            if (prop == null)
            {
                var mm = GetPublicMembers(_typeInstance).Where(it => it.Name == name).ToArray();
                prop = mm.FirstOrDefault() as PropertyInfo;
            }
            var mi = prop.GetMethod;
            dynamic data = mi.Invoke(_comInstance, null);

            return new ComDisposable(data, mi.ReturnType);
            
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var name = binder.Name;
            var prop = _typeInstance.GetProperty(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            if (prop == null)
            {
                var mm = GetPublicMembers(_typeInstance).Where(it => it.Name == name).ToArray();
                prop = mm.FirstOrDefault() as PropertyInfo;
            }
            var mi = prop.GetSetMethod();
            mi.Invoke(_comInstance, new object[1] {value});
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = GetMember(binder.Name);
            return true;

        }
        public static MemberInfo[] GetPublicMembers(Type type)
        {
            if (type.IsInterface)
            {
                var membersInfos = new List<MemberInfo>();

                var considered = new List<Type>();
                var queue = new Queue<Type>();
                considered.Add(type);
                queue.Enqueue(type);
                while (queue.Count > 0)
                {
                    var subType = queue.Dequeue();
                    foreach (var subInterface in subType.GetInterfaces())
                    {
                        if (considered.Contains(subInterface)) continue;

                        considered.Add(subInterface);
                        queue.Enqueue(subInterface);
                    }

                    var members = subType.GetMembers(
                        BindingFlags.FlattenHierarchy
                        | BindingFlags.Public
                        | BindingFlags.Instance);

                    var newMembers = members
                        .Where(x => !members.Contains(x));

                    membersInfos.InsertRange(0, members);
                }

                return membersInfos.ToArray();
            }

            return type.GetMembers(BindingFlags.FlattenHierarchy
                | BindingFlags.Public | BindingFlags.Instance);
        }

        ComDisposable InvokeMethod(string name, object[] args)
        {
            var mm = _typeInstance.GetMember(name,
                  BindingFlags.Public | BindingFlags.Instance);
            if (mm.Length == 0)
            {
                mm = GetPublicMembers(_typeInstance).Where(it => it.Name == name).ToArray();
            }
            //TODO: find the overloaded method with the same name and the signature args
            var mmInfo = mm.FirstOrDefault();
            MethodInfo mi = mmInfo as MethodInfo;
            if (mi == null)
            {
                var pi = mmInfo as PropertyInfo;
                mi = pi.GetGetMethod();
            }
            
            var argMethod = mi.GetParameters();

            if (args.Length < argMethod.Length)
            {
                var arg = new List<object>(args);
                while (arg.Count < argMethod.Length)
                {
                    arg.Add(Type.Missing);
                }
                args = arg.ToArray();
            }

            var data = mi.Invoke(_comInstance, args);
            return new ComDisposable(data, mi.ReturnType);
        }

        
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = InvokeMethod(binder.Name, args);
            return true;
            ;
        }
    }
}
