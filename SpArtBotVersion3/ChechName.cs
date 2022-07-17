using System;
using Discord;
using Discord.WebSocket;
using SpArtBotVersion3;
namespace SpArtBotVersion3
{
    public class ChechName
    {
        public string AceptArtName(string artName)
        {
            int start = 0;
            var argArray = artName.ToArray();
            string name = "";
            for (int i = 0; i < argArray.Length; i++)
            {
                if (argArray[i] == '|')
                {
                    if (start == 0)
                    {
                        start++;
                    }
                    else if (start == 1)
                    {
                        break;
                    }
                }
                else if (start == 1)
                {
                    name += argArray[i];
                }
            }
            return name;
        }
        public Task SeeName(string arg)
        {
            int start = 0;
            var argArray = arg.ToArray();
            string name = "";
            for (int i = 0; i < argArray.Length; i++)
            {
                if (argArray[i] == '"')
                {
                    if (start == 0)
                    {
                        start++;
                    }
                    else if (start == 1)
                    {
                        break;
                    }
                }
                else if (start == 1)
                {
                    name += argArray[i];
                }
            }
            Info.ArtName = name;
            return Task.CompletedTask;
        }
        public Task SeeNameAndPrice(SocketMessage arg)
        {
            var argstring = arg.ToString();
            string priceInString = "";
            bool nameSecondMark = false;
            string argText = argstring;
            char[] argChar = new char[argText.Length];
            argChar = argText.ToCharArray();
            for (int i = 0; i < argChar.Length; i++)
            {
                if (argChar[i] == '|')
                {
                    if (!nameSecondMark)
                    {
                        i++;
                        nameSecondMark = true;
                    }
                    else
                    {
                        nameSecondMark = false;
                    }
                }
                if (nameSecondMark)
                {
                    Info.Name += argChar[i];
                }
                if (argChar[i] == ':')
                {
                    int place = 0;
                    bool countinue = false;
                    i++;
                    for (int j = i; j < argChar.Length; j++)
                    {
                        if (argChar[j] == ')')
                        {
                            Info.IsNotForKid = false;
                            place = j + 1;
                            countinue = true;
                        }
                        else if (argChar[j] == ']')
                        {
                            Info.IsNotForKid = true;
                            place = j + 1;
                            countinue = true;
                        }
                        priceInString += argChar[j];
                        if (countinue == true)
                        {
                            Console.WriteLine(place);
                            for (int k = place; k < argChar.Length; k++)
                            {
                                Info.Link += argChar[k];
                            }
                            countinue = false;
                            break;
                        }
                    }
                    break;
                }
            }
            Info.Price = priceInString;
            return Task.CompletedTask;
        }
    }
}
