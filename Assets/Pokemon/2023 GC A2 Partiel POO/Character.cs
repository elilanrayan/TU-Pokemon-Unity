﻿using System;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Définition d'un personnage
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Stat de base, HP
        /// </summary>
        int _baseHealth =100;
        /// <summary>
        /// Stat de base, ATK
        /// </summary>
        int _baseAttack =50;
        /// <summary>
        /// Stat de base, DEF
        /// </summary>
        int _baseDefense = 30;
        /// <summary>
        /// Stat de base, SPE
        /// </summary>
        int _baseSpeed = 20;
        /// <summary>
        /// Type de base
        /// </summary>
        TYPE _baseType = TYPE.NORMAL;
        private int _priorityAttack = 0;
  
        private int currentHealth;

        public Character(int baseHealth, int baseAttack, int baseDefense, int baseSpeed, TYPE baseType)
        {
            _baseHealth = baseHealth;
            _baseAttack = baseAttack;
            _baseDefense = baseDefense;
            _baseSpeed = baseSpeed;
            _baseType = baseType;
        }
        /// <summary>
        /// HP actuel du personnage
        /// </summary>
        public int CurrentHealth { get => _baseHealth; private set => _baseHealth = value; }
        //public int CurrentHealth { get ; private set; }
        
        //public int CurrentHealth
        //{
        //    get
        //    {
        //        if(MaxHealth < currentHealth)
        //        {
        //            CurrentHealth = MaxHealth;
        //            return CurrentHealth;
        //        }
        //        return _baseHealth;
        //    }
        //    private set
        //    {
        //        if(value < MaxHealth)
        //        {
        //            _baseHealth += value;
        //        }
        //    }
        //}
        public TYPE BaseType { get => _baseType;}
        /// <summary>
        /// HPMax, prendre en compte base et equipement potentiel
        /// </summary>
        public int MaxHealth
        {
            get
            {
                if(CurrentEquipment != null)
                {
                    return CurrentEquipment.BonusHealth+ _baseHealth;
                }
                return _baseHealth;
            }
        }
        /// <summary>
        /// ATK, prendre en compte base et equipement potentiel
        /// </summary>
        public int Attack
        {
            get
            {
                if (CurrentEquipment != null)
                {
                    return CurrentEquipment.BonusAttack + _baseAttack;
                }
                return _baseAttack;
            }
        }
        /// <summary>
        /// DEF, prendre en compte base et equipement potentiel
        /// </summary>
        public int Defense
        {
            get
            {
                if (CurrentEquipment != null)
                {
                    return CurrentEquipment.BonusDefense + _baseDefense;
                }
                return _baseDefense;
            }
        }
        /// <summary>
        /// SPE, prendre en compte base et equipement potentiel
        /// </summary>
        public int Speed
        {
            get
            {
                if (CurrentEquipment != null)
                {
                    return CurrentEquipment.BonusSpeed + _baseSpeed;
                }
                return _baseSpeed;
            }
        }


        public int PriorityAttack
        {
            get
            {
                if (CurrentEquipment != null)
                {
                    return CurrentEquipment.PriorityAttack;
                }
                return _priorityAttack;
            }
        }
        /// <summary>
        /// Equipement unique du personnage
        /// </summary>
        /// 
        public Equipment CurrentEquipment { get; private set; }
        /// <summary>
        /// null si pas de status
        /// </summary>
        public StatusEffect CurrentStatus { get; private set; }

        public bool IsAlive
        {
            get
            {
                if(CurrentHealth <= 0)
                {
                    return false;
                }
                return true;
            }
        }


        /// <summary>
        /// Application d'un skill contre le personnage
        /// On pourrait potentiellement avoir besoin de connaitre le personnage attaquant,
        /// Vous pouvez adapter au besoin
        /// </summary>
        /// <param name="s">skill attaquant</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ReceiveAttack(Skill s)
        {
            int damage = Defense + CurrentHealth - s.Power;
            CurrentHealth = damage;
            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
            
            //CurrentStatus.CanAttack= s.Status;
           
        }
        /// <summary>
        /// Equipe un objet au personnage
        /// </summary>
        /// <param name="newEquipment">equipement a appliquer</param>
        /// <exception cref="ArgumentNullException">Si equipement est null</exception>
        public void Equip(Equipment newEquipment)
        {
            if(newEquipment == null)
            {
                throw new ArgumentNullException();
            }
            CurrentEquipment = newEquipment;
            
            //throw new NotImplementedException();
        }
        /// <summary>
        /// Desequipe l'objet en cours au personnage
        /// </summary>
        public void Unequip()
        {
            CurrentEquipment = null;
            //throw new NotImplementedException();
        }

        public void SetHealth(int health)
        {
            if(health + CurrentHealth > MaxHealth)
            {
                throw new ArgumentException("le health est supérieur a ton maxhealth", "int health");
            }
            CurrentHealth += health;
        }

    }
}
