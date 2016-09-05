using System.Reflection;
using System.Text;

namespace VS_Nuget_Extensions_DAL
{
    using System;



    
    public partial class PackageAdd
    {
   
     
     
      

      
        public string ProjectName { get; set; }

       public string NamePackage { get; set; }

       
        public string IdentifierPackage { get; set; }

       
        public string VersionPackage { get; set; }

    
        public override string ToString()
        {
            var _PropertyInfos =GetType().GetProperties();
            var sb = new StringBuilder();

            foreach (var info in _PropertyInfos)
            {
                if(!info.CanRead)
                    continue;
                
                var value = info.GetValue(this, null) ?? "(null)";
                sb.Append(info.Name + ": " + value.ToString()+";");
            }

            return sb.ToString();
        }
    }
}
