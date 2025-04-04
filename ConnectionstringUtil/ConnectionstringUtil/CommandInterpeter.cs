using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionstringUtil
{
    public class CommandInterpeter
    {
        public string[] Args { get; }
        public string Function => Args[0];

        public CommandInterpeter(string command)
        {
            var stringCommands = command.Split(' ');
            var currentSubstring = "";
            var argsList = new List<string>();
            var isBuildingString = false;
            foreach (var substring in stringCommands)
            {
                if (substring.Contains('"') && !isBuildingString)
                {
                    isBuildingString = true;
                    currentSubstring += $" {substring.Replace("\"", "")}";
                }
                else if (substring.Contains('"') && isBuildingString)
                {
                    isBuildingString = false;
                    currentSubstring += $" {substring.Replace("\"", "")}";
                }
                else
                {
                    currentSubstring += $" {substring}";
                }

                if (!isBuildingString)
                {
                    argsList.Add(currentSubstring.Trim());
                    currentSubstring = "";
                }
            }
            Args = argsList.ToArray();
        }
    }
}
