using System;

namespace MouseMover.WindowsApp
{

    [AttributeUsage(AttributeTargets.Assembly)]
    public class AssemblyCompanyUrl : Attribute
    {

        public string CompanyUrl { get; set; }

        public AssemblyCompanyUrl() : this(string.Empty) { }

        public AssemblyCompanyUrl(string companyUrl)
        {
            this.CompanyUrl = companyUrl; 
        }
    }

}