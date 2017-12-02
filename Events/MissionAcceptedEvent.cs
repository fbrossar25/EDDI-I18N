using EddiDataDefinitions;
using System;
using System.Collections.Generic;

namespace EddiEvents
{
    public class MissionAcceptedEvent: Event
    {
        public const string NAME = "Mission accepted";
        public const string DESCRIPTION = "Triggered when you accept a mission";
        public const string SAMPLE = "{ \"timestamp\":\"2017-09-27T11:03:32Z\", \"event\":\"MissionAccepted\", \"Faction\":\"Official Njula Focus\", \"Name\":\"Mission_Courier_Boom\", \"LocalisedName\":\"Livraison de données économiques\", \"TargetFaction\":\"HIP 12361 Free\", \"DestinationSystem\":\"HIP 12361\", \"DestinationStation\":\"Vess Gateway\", \"Expiry\":\"2017-09-28T11:02:51Z\", \"Influence\":\"Low\" \"Reputation\":\"Med\", \"Reward\":16812, \"MissionID\":213720915 }";

		public static Dictionary<string, string> VARIABLES = new Dictionary<string, string>();

        static MissionAcceptedEvent()
        {
            VARIABLES.Add("missionid", "The ID of the mission");
            VARIABLES.Add("name", "The name of the mission");
            VARIABLES.Add("faction", "The faction issuing the mission");
            VARIABLES.Add("destinationsystem", "The destination system for the mission (if applicable)");
            VARIABLES.Add("destinationstation", "The destination station for the mission (if applicable)");
            VARIABLES.Add("commodity", "The commodity involved in the mission (if applicable)");
            VARIABLES.Add("LocalCommodity", "The translation of the commodity into the chosen language (if applicable)");
            VARIABLES.Add("amount", "The amount of the commodity,  passengers or targets involved in the mission (if applicable)");
            VARIABLES.Add("passengertype", "The type of passengers in the mission (if applicable)");
            VARIABLES.Add("passengerswanted", "True if the passengers are wanted (if applicable)");
            VARIABLES.Add("target", "Name of the target of the mission (if applicable)");
            VARIABLES.Add("targettype", "Type of the target of the mission (if applicable)");
            VARIABLES.Add("targetfaction", "Faction of the target of the mission (if applicable)");
            VARIABLES.Add("communal", "True if the mission is a community goal");
            VARIABLES.Add("expiry", "The expiry date of the mission");
            VARIABLES.Add("influence", "The increase in the faction's influence in the system gained when completing this mission (None/Low/Med/High)");
            VARIABLES.Add("reputation", "The increase in the commander's reputation with the faction gained when completing this mission (None/Low/Med/High)");
            VARIABLES.Add("LocalName", "the human readable name on the mission (the ED Localised name)");
        }

        public long? missionid { get; private set; }

        public string name { get; private set; }

        public string faction { get; private set; }

        public string commodity { get; private set; }

        public string LocalCommodity
        {
            get
            {
                if (commodity != null && commodity != "")
                {
                    return CommodityDefinitions.FromName(commodity).LocalName;
                }
                else return null;
            }
        }

        public int? amount { get; private set; }

        public string destinationsystem { get; private set; }

        public string destinationstation { get; private set; }

        public string passengertype { get; private set; }

        public bool? passengerswanted { get; private set; }

        public string target { get; private set; }

        public string targettype { get; private set; }

        public string targetfaction { get; private set; }

        public bool communal { get; private set; }

        public DateTime? expiry { get; private set; }

        public string influence { get; private set; }

        public string reputation { get; private set; }

        public string LocalName { get; private set; }

        public MissionAcceptedEvent(DateTime timestamp, long? missionid, string name, string LocalisedName, string faction, string destinationsystem, string destinationstation, Commodity commodity, int? amount, string passengertype, bool? passengerswanted, string target, string targettype, string targetfaction, bool communal, DateTime? expiry, string influence, string reputation) : base(timestamp, NAME)
        {
            this.missionid = missionid;
            this.name = name;
            this.LocalName = LocalisedName;
            this.faction = faction;
            this.destinationsystem = destinationsystem;
            this.destinationstation = destinationstation;
            this.commodity = (commodity == null ? null : commodity.name);
            this.amount = amount;
            this.passengertype = passengertype;
            this.passengerswanted = passengerswanted;
            this.target = target;
            this.targettype = targettype;
            this.targetfaction = targetfaction;
            this.communal = communal;
            this.expiry = expiry;
            this.influence = influence;
            this.reputation = reputation;
        }
    }
}
