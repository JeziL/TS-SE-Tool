﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TS_SE_Tool.Save.DataFormat;

namespace TS_SE_Tool.Save.Items
{
    class Company : SiiNBlockCore
    {
        internal string permanent_data { get; set; } = "";

        internal string delivered_trailer { get; set; } = "";

        internal List<SCS_Placement> delivered_pos { get; set; } = new List<SCS_Placement>();

        internal List<string> job_offer { get; set; } = new List<string>();

        internal List<uint> cargo_offer_seeds { get; set; } = new List<uint>();

        internal bool discovered { get; set; } = false;

        internal int? reserved_trailer_slot { get; set; } = null;

        internal uint state { get; set; } = 0;

        internal uint state_change_time { get; set; } = 0;

        internal Company()
        { }

        internal Company(string[] _input)
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
                try
                {
                    switch (tagLine)
                    {
                        case "":
                            {
                                break;
                            }

                        case "permanent_data":
                            {
                                permanent_data = dataLine;
                                break;
                            }

                        case "delivered_trailer":
                            {
                                delivered_trailer = dataLine;
                                break;
                            }

                        case "delivered_pos":
                            {
                                delivered_pos.Capacity = int.Parse(dataLine);
                                break;
                            }

                        case var s when s.StartsWith("delivered_pos["):
                            {
                                delivered_pos.Add(new SCS_Placement(dataLine));
                                break;
                            }

                        case "job_offer":
                            {
                                job_offer.Capacity = int.Parse(dataLine);
                                break;
                            }

                        case var s when s.StartsWith("job_offer["):
                            {
                                job_offer.Add(dataLine);
                                break;
                            }

                        case "cargo_offer_seeds":
                            {
                                cargo_offer_seeds.Capacity = int.Parse(dataLine);
                                break;
                            }

                        case var s when s.StartsWith("cargo_offer_seeds["):
                            {
                                cargo_offer_seeds.Add(uint.Parse(dataLine));
                                break;
                            }

                        case "discovered":
                            {
                                discovered = bool.Parse(dataLine);
                                break;
                            }

                        case "reserved_trailer_slot":
                            {
                                reserved_trailer_slot = dataLine == "nil" ? (int?)null : int.Parse(dataLine);
                                break;
                            }

                        case "state":
                            {
                                state = uint.Parse(dataLine);
                                break;
                            }

                        case " state_change_time":
                            {
                                state_change_time = uint.Parse(dataLine);
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Utilities.IO_Utilities.ErrorLogWriter(ex.Message + Environment.NewLine + this.GetType().Name.ToLower() + " | " + tagLine + " = " + dataLine);
                    break;
                }
            }
        }

        internal string PrintOut(uint _version, string _nameless)
        {
            string returnString = "";

            StringBuilder returnSB = new StringBuilder();

            returnSB.AppendLine("company : " + _nameless + " {");

            returnSB.AppendLine(" permanent_data: " + permanent_data);

            returnSB.AppendLine(" delivered_trailer: " + delivered_trailer);

            returnSB.AppendLine(" delivered_pos: " + delivered_pos.Count);
            for (int i = 0; i < delivered_pos.Count; i++)
                returnSB.AppendLine(" delivered_pos[" + i + "]: " + delivered_pos[i].ToString());

            returnSB.AppendLine(" job_offer: " + job_offer.Count);
            for (int i = 0; i < job_offer.Count; i++)
                returnSB.AppendLine(" job_offer[" + i + "]: " + job_offer[i]);

            returnSB.AppendLine(" cargo_offer_seeds: " + cargo_offer_seeds.Count);
            for (int i = 0; i < cargo_offer_seeds.Count; i++)
                returnSB.AppendLine(" cargo_offer_seeds[" + i + "]: " + cargo_offer_seeds[i].ToString());

            returnSB.AppendLine(" discovered: " + discovered.ToString().ToLower());

            returnSB.AppendLine(" reserved_trailer_slot: " + (reserved_trailer_slot == null ? "nil" : reserved_trailer_slot.ToString()));

            if (_version >= (byte)saveVTV.v146)
            {
                returnSB.AppendLine(" state: " + state.ToString());
                returnSB.AppendLine(" state_change_time: " + state_change_time.ToString());
            }

            returnSB.AppendLine("}");

            returnString = returnSB.ToString();

            this.removeWritenBlock(_nameless);

            return returnString;
        }
    }
}