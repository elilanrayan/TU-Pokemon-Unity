
using System;
using UnityEngine.TextCore.Text;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    public class Fight
    {
        Character _character1;
        Character _character2;
        public Fight(Character character1, Character character2)
        {
            if (character1 == null || character2 == null)
            {
                throw new ArgumentNullException();
            }
            _character1 = character1;
            _character2 = character2;
        }

        public Character Character1 { get => _character1; }
        public Character Character2 { get => _character2; }
        /// <summary>
        /// Est-ce la condition de victoire/défaite a été rencontré ?
        /// </summary>
        public bool IsFightFinished
        {
            get
            {
                if(Character1.IsAlive && Character2.IsAlive)
                {
                    return false;
                }
                return true;
            }
            
        }

        /// <summary>
        /// Jouer l'enchainement des attaques. Attention à bien gérer l'ordre des attaques par apport à la speed des personnages
        /// </summary>
        /// <param name="skillFromCharacter1">L'attaque selectionné par le joueur 1</param>
        /// <param name="skillFromCharacter2">L'attaque selectionné par le joueur 2</param>
        /// <exception cref="ArgumentNullException">si une des deux attaques est null</exception>
        public void ExecuteTurn(Skill skillFromCharacter1, Skill skillFromCharacter2)
        {
            Character firstAttack;
            Skill skillfirst;
            Character secondAttack;
            Skill skillsecond;
            if(Character1.Speed > Character2.Speed)
            {
                firstAttack = Character1;
                skillfirst = skillFromCharacter1;
                secondAttack = Character2;
                skillsecond = skillFromCharacter2;
            }
            else
            {
                firstAttack = Character2;
                skillfirst = skillFromCharacter2;
                secondAttack = Character1;
                skillsecond = skillFromCharacter1;
            }

            //while (true)
            //{
                secondAttack.ReceiveAttack(skillfirst);
                firstAttack.ReceiveAttack(skillsecond);

                if ((Character1.IsAlive == false) || (Character2.IsAlive == false))
                {
                    return;
                }
           // }
            
            
        }

    }
}
