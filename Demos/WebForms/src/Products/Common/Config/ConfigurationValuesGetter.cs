using System;

namespace GroupDocs.Viewer.WebForms.Products.Common.Config
{
    public class ConfigurationValuesGetter
    {
        private readonly dynamic Configuration;

        public ConfigurationValuesGetter(dynamic configuration)
        {
            this.Configuration = configuration;
        }

        public string GetStringPropertyValue(string propertyName)
        {
            return (this.Configuration != null && this.Configuration[propertyName] != null && !string.IsNullOrEmpty(this.Configuration[propertyName].ToString())) ?
                this.Configuration[propertyName].ToString() :
                null;
        }

        public string GetStringPropertyValue(string propertyName, string defaultValue)
        {
            return (this.Configuration != null && this.Configuration[propertyName] != null && !string.IsNullOrEmpty(this.Configuration[propertyName].ToString())) ?
                this.Configuration[propertyName].ToString() :
                defaultValue;
        }

        public int GetIntegerPropertyValue(string propertyName, int defaultValue)
        {
            int value;
            value = (this.Configuration != null && this.Configuration[propertyName] != null && !string.IsNullOrEmpty(this.Configuration[propertyName].ToString())) ?
                Convert.ToInt32(this.Configuration[propertyName]) :
                defaultValue;
            return value;
        }

        public int GetIntegerPropertyValue(string propertyName, int defaultValue, string innerPropertyName)
        {
            int value;
            if (!string.IsNullOrEmpty(innerPropertyName))
            {
                value = (this.Configuration != null && this.Configuration[propertyName] != null && !string.IsNullOrEmpty(this.Configuration[propertyName][innerPropertyName].ToString())) ?
                    Convert.ToInt32(this.Configuration[propertyName][innerPropertyName]) :
                    defaultValue;
            }
            else
            {
                value = (this.Configuration != null && this.Configuration[propertyName] != null && !string.IsNullOrEmpty(this.Configuration[propertyName].ToString())) ?
                    Convert.ToInt32(this.Configuration[propertyName]) :
                    defaultValue;
            }

            return value;
        }

        public bool GetBooleanPropertyValue(string propertyName, bool defaultValue)
        {
            return (this.Configuration != null && this.Configuration[propertyName] != null && !string.IsNullOrEmpty(this.Configuration[propertyName].ToString())) ? Convert.ToBoolean(this.Configuration[propertyName]) : defaultValue;
        }
    }
}