using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.MouseMover.WinFormsApp
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