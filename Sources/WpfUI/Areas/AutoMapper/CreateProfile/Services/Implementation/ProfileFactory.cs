using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Mmu.Cg.WpfUI.Areas.AutoMapper.CreateProfile.Services.Implementation
{
    public class ProfileFactory : IProfileFactory
    {
        public string CreateProfile(string dtoDefinition)
        {
            const string MappingTemplate = @".ForMember(d => d.{0}, c => c.MapFrom(f => f.{0}))";

            var propertyMaps = dtoDefinition
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(GetPropertyName)
                .Where(propName => !string.IsNullOrEmpty(propName))
                .Select(propName => string.Format(MappingTemplate, propName))
                .ToArray();

            var sb = new StringBuilder();

            for (var i = 0; i < propertyMaps.Length; i++)
            {
                if (i < propertyMaps.Length - 1)
                {
                    sb.AppendLine(propertyMaps[i]);
                }
                else
                {
                    sb.Append(propertyMaps[i]);
                    sb.AppendLine(";");
                }
            }

            return sb.ToString();
        }

        private static string GetPropertyName(string propertyLine)
        {
            const string GetPart = "{ get";
            const string RegexTemplate = @"(\S+)\s+({0})";

            var regexStr = string.Format(RegexTemplate, GetPart);
            var regex = new Regex(regexStr);
            var match = regex.Match(propertyLine);

            if (!match.Success)
            {
                return string.Empty;
            }

            var matchResult = match.Groups[0].Value;
            matchResult = matchResult.Replace(GetPart, string.Empty).Trim();
            return matchResult;
        }
    }
}