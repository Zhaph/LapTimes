﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("LapTimes", "RaceCurrentRacer", "Race", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(LapTimes.Models.Race), "CurrentRacer", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(LapTimes.Models.CurrentRacer), true)]
[assembly: EdmRelationshipAttribute("LapTimes", "RacerClassName", "Racer", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(LapTimes.Models.Racer), "ClassName", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(LapTimes.Models.ClassName), true)]
[assembly: EdmRelationshipAttribute("LapTimes", "RacerLeague", "Racer", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(LapTimes.Models.Racer), "League", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(LapTimes.Models.League), true)]

#endregion

namespace LapTimes.Models
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class LapTimesContainer : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new LapTimesContainer object using the connection string found in the 'LapTimesContainer' section of the application configuration file.
        /// </summary>
        public LapTimesContainer() : base("name=LapTimesContainer", "LapTimesContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new LapTimesContainer object.
        /// </summary>
        public LapTimesContainer(string connectionString) : base(connectionString, "LapTimesContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new LapTimesContainer object.
        /// </summary>
        public LapTimesContainer(EntityConnection connection) : base(connection, "LapTimesContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Race> Races
        {
            get
            {
                if ((_Races == null))
                {
                    _Races = base.CreateObjectSet<Race>("Races");
                }
                return _Races;
            }
        }
        private ObjectSet<Race> _Races;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Racer> Racers
        {
            get
            {
                if ((_Racers == null))
                {
                    _Racers = base.CreateObjectSet<Racer>("Racers");
                }
                return _Racers;
            }
        }
        private ObjectSet<Racer> _Racers;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<League> Leagues
        {
            get
            {
                if ((_Leagues == null))
                {
                    _Leagues = base.CreateObjectSet<League>("Leagues");
                }
                return _Leagues;
            }
        }
        private ObjectSet<League> _Leagues;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<ClassName> ClassNames
        {
            get
            {
                if ((_ClassNames == null))
                {
                    _ClassNames = base.CreateObjectSet<ClassName>("ClassNames");
                }
                return _ClassNames;
            }
        }
        private ObjectSet<ClassName> _ClassNames;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Races EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToRaces(Race race)
        {
            base.AddObject("Races", race);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Racers EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToRacers(Racer racer)
        {
            base.AddObject("Racers", racer);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Leagues EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToLeagues(League league)
        {
            base.AddObject("Leagues", league);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the ClassNames EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToClassNames(ClassName className)
        {
            base.AddObject("ClassNames", className);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="LapTimes", Name="ClassName")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class ClassName : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new ClassName object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        public static ClassName CreateClassName(global::System.Int32 id, global::System.String name)
        {
            ClassName className = new ClassName();
            className.Id = id;
            className.Name = name;
            return className;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("LapTimes", "RacerClassName", "Racer")]
        public EntityCollection<Racer> Racers
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Racer>("LapTimes.RacerClassName", "Racer");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Racer>("LapTimes.RacerClassName", "Racer", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="LapTimes", Name="CurrentRacer")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class CurrentRacer : Racer
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new CurrentRacer object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="bestTime">Initial value of the BestTime property.</param>
        /// <param name="classNameId">Initial value of the ClassNameId property.</param>
        /// <param name="leagueId">Initial value of the LeagueId property.</param>
        /// <param name="raceId">Initial value of the RaceId property.</param>
        /// <param name="raceTime">Initial value of the RaceTime property.</param>
        public static CurrentRacer CreateCurrentRacer(global::System.Int32 id, global::System.String name, global::System.Int32 bestTime, global::System.Int32 classNameId, global::System.Int32 leagueId, global::System.Int32 raceId, global::System.Int32 raceTime)
        {
            CurrentRacer currentRacer = new CurrentRacer();
            currentRacer.Id = id;
            currentRacer.Name = name;
            currentRacer.BestTime = bestTime;
            currentRacer.ClassNameId = classNameId;
            currentRacer.LeagueId = leagueId;
            currentRacer.RaceId = raceId;
            currentRacer.RaceTime = raceTime;
            return currentRacer;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 RaceId
        {
            get
            {
                return _RaceId;
            }
            set
            {
                OnRaceIdChanging(value);
                ReportPropertyChanging("RaceId");
                _RaceId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("RaceId");
                OnRaceIdChanged();
            }
        }
        private global::System.Int32 _RaceId;
        partial void OnRaceIdChanging(global::System.Int32 value);
        partial void OnRaceIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 RaceTime
        {
            get
            {
                return _RaceTime;
            }
            set
            {
                OnRaceTimeChanging(value);
                ReportPropertyChanging("RaceTime");
                _RaceTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("RaceTime");
                OnRaceTimeChanged();
            }
        }
        private global::System.Int32 _RaceTime;
        partial void OnRaceTimeChanging(global::System.Int32 value);
        partial void OnRaceTimeChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("LapTimes", "RaceCurrentRacer", "Race")]
        public Race Race
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Race>("LapTimes.RaceCurrentRacer", "Race").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Race>("LapTimes.RaceCurrentRacer", "Race").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Race> RaceReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Race>("LapTimes.RaceCurrentRacer", "Race");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Race>("LapTimes.RaceCurrentRacer", "Race", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="LapTimes", Name="League")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class League : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new League object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="description">Initial value of the Description property.</param>
        public static League CreateLeague(global::System.Int32 id, global::System.String name, global::System.String description)
        {
            League league = new League();
            league.Id = id;
            league.Name = name;
            league.Description = description;
            return league;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("LapTimes", "RacerLeague", "Racer")]
        public EntityCollection<Racer> Racers
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Racer>("LapTimes.RacerLeague", "Racer");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Racer>("LapTimes.RacerLeague", "Racer", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="LapTimes", Name="Race")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Race : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Race object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="startTime">Initial value of the StartTime property.</param>
        /// <param name="endTime">Initial value of the EndTime property.</param>
        public static Race CreateRace(global::System.Int32 id, global::System.DateTime startTime, global::System.DateTime endTime)
        {
            Race race = new Race();
            race.Id = id;
            race.StartTime = startTime;
            race.EndTime = endTime;
            return race;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean IsComplete
        {
            get
            {
                return _IsComplete;
            }
            set
            {
                OnIsCompleteChanging(value);
                ReportPropertyChanging("IsComplete");
                _IsComplete = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsComplete");
                OnIsCompleteChanged();
            }
        }
        private global::System.Boolean _IsComplete = false;
        partial void OnIsCompleteChanging(global::System.Boolean value);
        partial void OnIsCompleteChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime StartTime
        {
            get
            {
                return _StartTime;
            }
            set
            {
                OnStartTimeChanging(value);
                ReportPropertyChanging("StartTime");
                _StartTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("StartTime");
                OnStartTimeChanged();
            }
        }
        private global::System.DateTime _StartTime;
        partial void OnStartTimeChanging(global::System.DateTime value);
        partial void OnStartTimeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime EndTime
        {
            get
            {
                return _EndTime;
            }
            set
            {
                OnEndTimeChanging(value);
                ReportPropertyChanging("EndTime");
                _EndTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("EndTime");
                OnEndTimeChanged();
            }
        }
        private global::System.DateTime _EndTime;
        partial void OnEndTimeChanging(global::System.DateTime value);
        partial void OnEndTimeChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("LapTimes", "RaceCurrentRacer", "CurrentRacer")]
        public EntityCollection<CurrentRacer> CurrentRacers
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<CurrentRacer>("LapTimes.RaceCurrentRacer", "CurrentRacer");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<CurrentRacer>("LapTimes.RaceCurrentRacer", "CurrentRacer", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="LapTimes", Name="Racer")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    [KnownTypeAttribute(typeof(CurrentRacer))]
    public partial class Racer : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Racer object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="bestTime">Initial value of the BestTime property.</param>
        /// <param name="classNameId">Initial value of the ClassNameId property.</param>
        /// <param name="leagueId">Initial value of the LeagueId property.</param>
        public static Racer CreateRacer(global::System.Int32 id, global::System.String name, global::System.Int32 bestTime, global::System.Int32 classNameId, global::System.Int32 leagueId)
        {
            Racer racer = new Racer();
            racer.Id = id;
            racer.Name = name;
            racer.BestTime = bestTime;
            racer.ClassNameId = classNameId;
            racer.LeagueId = leagueId;
            return racer;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 BestTime
        {
            get
            {
                return _BestTime;
            }
            set
            {
                OnBestTimeChanging(value);
                ReportPropertyChanging("BestTime");
                _BestTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("BestTime");
                OnBestTimeChanged();
            }
        }
        private global::System.Int32 _BestTime;
        partial void OnBestTimeChanging(global::System.Int32 value);
        partial void OnBestTimeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ClassNameId
        {
            get
            {
                return _ClassNameId;
            }
            set
            {
                OnClassNameIdChanging(value);
                ReportPropertyChanging("ClassNameId");
                _ClassNameId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ClassNameId");
                OnClassNameIdChanged();
            }
        }
        private global::System.Int32 _ClassNameId;
        partial void OnClassNameIdChanging(global::System.Int32 value);
        partial void OnClassNameIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 LeagueId
        {
            get
            {
                return _LeagueId;
            }
            set
            {
                OnLeagueIdChanging(value);
                ReportPropertyChanging("LeagueId");
                _LeagueId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LeagueId");
                OnLeagueIdChanged();
            }
        }
        private global::System.Int32 _LeagueId;
        partial void OnLeagueIdChanging(global::System.Int32 value);
        partial void OnLeagueIdChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("LapTimes", "RacerClassName", "ClassName")]
        public ClassName ClassName
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<ClassName>("LapTimes.RacerClassName", "ClassName").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<ClassName>("LapTimes.RacerClassName", "ClassName").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<ClassName> ClassNameReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<ClassName>("LapTimes.RacerClassName", "ClassName");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<ClassName>("LapTimes.RacerClassName", "ClassName", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("LapTimes", "RacerLeague", "League")]
        public League League
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<League>("LapTimes.RacerLeague", "League").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<League>("LapTimes.RacerLeague", "League").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<League> LeagueReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<League>("LapTimes.RacerLeague", "League");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<League>("LapTimes.RacerLeague", "League", value);
                }
            }
        }

        #endregion

    }

    #endregion

    
}