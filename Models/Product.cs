using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceSite.Models
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
        [HiddenInput(DisplayValue = false)]
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            //Name rule
            if (String.IsNullOrEmpty(Name))
                yield return new RuleViolation("Item needs a name", "Name");
            //Price rule
            if (String.IsNullOrEmpty(Price))
                yield return new RuleViolation("A price is reqiured", "Price");
            //Description rule
            if (String.IsNullOrEmpty(Description))
                yield return new RuleViolation("Please describe the item", "Description");
            //Image rule
            if (String.IsNullOrEmpty(Image))
                yield return new RuleViolation("Please enter image name", "Image");
            //Features rule
            if (String.IsNullOrEmpty(Features))
                yield return new RuleViolation("Item needs at least 3 features, delimited by commas", "Features");

            yield break;
        }

        partial void OnValidate(ChangeAction action)
        {
            if (!IsValid)
                throw new ApplicationException("Rule violations prevent saving.");
        }

    }


    //Helper class
    public class RuleViolation
    {
        public string ErrorMessage { get; private set; }
        public string PropertyName { get; private set; }

        public RuleViolation(string errorMessage, string propertyName)
        {
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
        }
    }

    public class ProductMetaData
    {
        [HiddenInput(DisplayValue = false)]
        public object Id { get; set; }
        
        public object Name { get; set; }
        public object Price { get; set; }
        
        [DataType(DataType.MultilineText)]
        public object Description { get; set; }
        
        public object Image { get; set; }

        [DataType(DataType.MultilineText)]        
        public object Features { get; set; }
    }
}