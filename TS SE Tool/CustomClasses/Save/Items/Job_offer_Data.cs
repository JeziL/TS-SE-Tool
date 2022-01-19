﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS_SE_Tool.Save.Items
{
    class Job_offer_Data
    {
        internal string target { get; set; } = "";

        internal int expiration_time { get; set; } = 0;

        internal int urgency { get; set; } = 0;

        internal int shortest_distance_km { get; set; } = 0;

        internal int ferry_time { get; set; } = 0;
        internal int ferry_price { get; set; } = 0;

        internal string cargo { get; set; } = "";

        internal string company_truck { get; set; } = "";

        internal string trailer_variant { get; set; } = "";
        internal string trailer_definition { get; set; } = "";

        internal int units_count { get; set; } = 0;

        internal int fill_ratio { get; set; } = 0;

        internal int trailer_place { get; set; } = 0;


        internal Job_offer_Data()
        { }

        internal Job_offer_Data(string[] _input)
        {
            string tagLine = "", dataLine = "";

            foreach (string currentLine in _input)
            {
                if (currentLine.Contains(':'))
                {
                    string[] splittedLine = currentLine.Split(new char[] { ':' }, 2);

                    tagLine = splittedLine[0].Trim();
                    dataLine = splittedLine[1].Trim();
                }
                else
                {
                    tagLine = currentLine.Trim();
                    dataLine = "";
                }

                switch (tagLine)
                {
                    case "":
                        {
                            break;
                        }

                    case "target":
                        {
                            target = dataLine;
                            break;
                        }

                    case "expiration_time":
                        {
                            expiration_time = int.Parse(dataLine);
                            break;
                        }

                    case "urgency":
                        {
                            urgency = int.Parse(dataLine);
                            break;
                        }

                    case "shortest_distance_km":
                        {
                            shortest_distance_km = int.Parse(dataLine);
                            break;
                        }

                    case "ferry_time":
                        {
                            ferry_time = int.Parse(dataLine);
                            break;
                        }

                    case "ferry_price":
                        {
                            ferry_price = int.Parse(dataLine);
                            break;
                        }

                    case "cargo":
                        {
                            cargo = dataLine;
                            break;
                        }

                    case "company_truck":
                        {
                            company_truck = dataLine;
                            break;
                        }

                    case "trailer_variant":
                        {
                            trailer_variant = dataLine;
                            break;
                        }

                    case "trailer_definition":
                        {
                            trailer_definition = dataLine;
                            break;
                        }

                    case "units_count":
                        {
                            units_count = int.Parse(dataLine);
                            break;
                        }

                    case "fill_ratio":
                        {
                            fill_ratio = int.Parse(dataLine);
                            break;
                        }

                    case "trailer_place":
                        {
                            trailer_place = int.Parse(dataLine);
                            break;
                        }

                }
            }
        }

        internal string PrintOut(uint _version, string _nameless)
        {
            string returnString = "";

            StringBuilder returnSB = new StringBuilder();

            returnSB.AppendLine("job_offer_data : " + _nameless + " {");

            returnSB.AppendLine(" target: " + target);

            returnSB.AppendLine(" expiration_time: " + expiration_time.ToString());
            returnSB.AppendLine(" urgency: " + urgency.ToString());
            returnSB.AppendLine(" shortest_distance_km: " + shortest_distance_km.ToString());
            returnSB.AppendLine(" ferry_time: " + ferry_time.ToString());
            returnSB.AppendLine(" ferry_price: " + ferry_price.ToString());

            returnSB.AppendLine(" cargo: " + cargo);

            returnSB.AppendLine(" company_truck: " + company_truck);

            returnSB.AppendLine(" trailer_variant: " + trailer_variant);
            returnSB.AppendLine(" trailer_definition: " + trailer_definition);

            returnSB.AppendLine(" units_count: " + units_count.ToString());
            returnSB.AppendLine(" fill_ratio: " + fill_ratio.ToString());
            returnSB.AppendLine(" trailer_place: " + trailer_place.ToString());

            returnSB.AppendLine("}");

            returnString = returnSB.ToString();

            return returnString;
        }
    }
}