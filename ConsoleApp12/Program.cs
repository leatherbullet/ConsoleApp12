using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAttack = "1";
            const string CommandAttackFireBall = "2";
            const string CommandAttackExplosion = "3";
            const string CommandRecovery = "4";

            int healthPlayer = 100;
            int damagePlayer = 7;
            int playerMana = 100;
            int costFireBall = 25;
            int costExplosion = 50;
            int fireBallDamage = 12;
            int explosionDamage = 25;
            int recoveryHealthAndMana = 20;
            int tryRecoveryHealthAndMana = 4;
            int maxValuePlayerHealth = 100;
            int maxValueMana = 100;

            bool canExplosionUse = false;
            bool canUseExplosion = false;
            bool isUseFireBall = true;

            string userChoice;

            int healthBoss = 100;
            int damageBoss = 15;

            while (healthPlayer > 0 && healthBoss > 0)
            {
                Console.Clear();
                Console.WriteLine($"У вас:\n{healthPlayer} здоровья\n{playerMana} маны");
                Console.WriteLine($"Босс:\n{healthBoss} здоровья");
                Console.WriteLine("Выберете действие: ");
                Console.WriteLine($"{CommandAttack}- простая атака");
                Console.WriteLine($"{CommandAttackFireBall}- атака огненным шаром. Стоимость:{costFireBall} маны");
                Console.WriteLine($"{CommandAttackExplosion}- атака взрывом:{canUseExplosion} Стоимость:{costExplosion} маны");
                Console.WriteLine($"{CommandRecovery}- востановить здоровье и ману на:{recoveryHealthAndMana} едениц. Осталось использований:{tryRecoveryHealthAndMana}");
                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case CommandAttack:
                        healthBoss -= damagePlayer;
                        Console.WriteLine($"Вы нанесли:{damagePlayer} едениц урона");
                        Console.ReadKey();
                        break;

                    case CommandAttackFireBall:
                        if (playerMana >= costFireBall)
                        {
                            healthBoss -= fireBallDamage;
                            playerMana -= costFireBall;
                            canUseExplosion = isUseFireBall;
                            Console.WriteLine($"Вы использовали огненый шар и нанесли:{fireBallDamage} урона");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Вы пропускаете ход");
                            Console.ReadKey();
                        }
                        break;

                    case CommandAttackExplosion:
                        if (playerMana >= costExplosion && canUseExplosion == isUseFireBall)
                        {
                            healthBoss -= explosionDamage;
                            playerMana -= costExplosion;
                            canUseExplosion = canExplosionUse;
                            Console.WriteLine($"Вы использовали взрыв и нанесли:{explosionDamage} урона");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Условия использования заклинания Взрыв не выполнены. Вы пропускаете ход");
                            Console.ReadKey();
                        }
                        break;

                    case CommandRecovery:
                        if (tryRecoveryHealthAndMana > 0)
                        {
                            tryRecoveryHealthAndMana--;
                            healthPlayer += recoveryHealthAndMana;
                            playerMana += recoveryHealthAndMana;

                            if(healthPlayer >= maxValuePlayerHealth)
                            {
                                healthPlayer = maxValuePlayerHealth;
                            }
                            if(playerMana >= maxValueMana)
                            {
                                playerMana = maxValueMana;
                            }

                            Console.WriteLine($"Вы восстановили здоровье и ману на:{recoveryHealthAndMana} едениц");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("У вас не осталось восстановлений. Вы пропускаете ход");
                        }
                        break;

                    default:
                        Console.WriteLine("Неверный ввод, вы пропускаете ход");
                        break;
                }
                    healthPlayer -= damageBoss;
                    Console.WriteLine($"Вы получили:{damageBoss} урона");
                    Console.ReadKey(); 
            }
            
            if (healthPlayer <= 0 && healthBoss <= 0)
            {
                Console.WriteLine("Ничья");
                Console.ReadKey();
            }
            else if (healthBoss <= 0)
            {
                Console.WriteLine("Вы победили");
                Console.ReadKey();
            }
            else if (healthPlayer <= 0)
            {
                Console.WriteLine("Вы проиграли");
                Console.ReadKey();
            }
        }
    }
}
