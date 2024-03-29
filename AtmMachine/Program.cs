﻿using System;

namespace AtmMachine
{
    class Atm
    {
        int sav_pin = 1234;
        public double sav_balance = new Random().Next(10000, 99999);
        public double curr_balance = new Random().Next(1000, 9999);
        public int t_acc;
        public double t_amt;
        public int pin;

        public void displayBal()
        {
            int ch = 0;
            ch = Acc_type();
            switch (ch)
            {
                case 1:
                    Console.WriteLine("Your balance is {0}", curr_balance);
                    break;
                case 2:
                    Console.WriteLine("Your balance is {0}", sav_balance);
                    break;
                default:
                    Console.WriteLine("Enter valid choice");
                    break;
            }
        }
        public void deposit()
        {
            Console.WriteLine("Enter amount to be deposited");
            double t_amt = Convert.ToDouble(Console.ReadLine());
            t_acc = Acc_type();
            if (t_acc == 1)
            {
                curr_balance = Math.Round((double)curr_balance + t_amt, 2);
                Console.WriteLine("Deposited");
            }
            else if (t_acc == 2)
            {
                sav_balance = Math.Round((double)sav_balance + t_amt, 2);
                Console.WriteLine("Deposited");
            }
            else
            {
                Console.WriteLine("Incorrect choice");
            }
        }
        public void transfer()
        {
            Console.WriteLine("Enter account number");
            long acc_no = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Amount");
            t_amt = Convert.ToDouble(Console.ReadLine());
            t_acc = Acc_type();
            Console.WriteLine("Enter PIN");
            pin = Convert.ToInt32(Console.ReadLine());
            if (pin == sav_pin)
            {
                if (t_acc == 1 && t_amt <= curr_balance)
                {
                    curr_balance = Math.Round((double)curr_balance - t_amt, 2);
                    Console.WriteLine("Money Transfered");
                }
                else if (t_acc == 2 && t_amt <= sav_balance)
                {
                    sav_balance = Math.Round((double)sav_balance - t_amt, 2);
                    Console.WriteLine("Money Transfered");
                }
                else
                {
                    Console.WriteLine("Insufficient amount");
                }
            }
            else
                Console.WriteLine("Incorrect PIN");
        }
        public void pinUpdate()
        {
            Console.WriteLine("Enter old PIN");
            pin = Convert.ToInt32(Console.ReadLine());
            if (pin == sav_pin)
            {
                Console.WriteLine("Enter new PIN");
                int pinn = Convert.ToInt32(Console.ReadLine());
                if (sav_pin == pinn)
                {
                    Console.WriteLine("New Pin cannot be same as old pin");
                }
                else
                {
                    sav_pin = pinn;
                    Console.WriteLine("PIN updated");
                }
            }
            else
            {
                Console.WriteLine("Incorrect Pin");
            }
        }
        public void Amt(int withAmount)
        {
            int twok = 0;
            do
            {
                if (withAmount >= 100)
                {
                    if (withAmount == 100)
                    {
                        Console.WriteLine("1 Note of 100", twok);
                        break;
                    }
                    else if (withAmount >= 200 && withAmount < 500)
                    {
                        withAmount = two_check(twok, withAmount);
                    }
                    else if (withAmount >= 100 && withAmount >= 200 && withAmount >= 500 && withAmount < 2000)
                    {
                        withAmount = five_check(twok, withAmount);

                        if (withAmount >= 100 && withAmount >= 200 && withAmount < 500)
                        {
                            withAmount = two_check(twok, withAmount);
                        }
                    }
                    else if (withAmount >= 100 && withAmount >= 200 && withAmount >= 500 && withAmount >= 2000)
                    {
                        twok = (int)withAmount / 2000;
                        Console.WriteLine("{0} Notes of 2000", twok);
                        withAmount = (int)withAmount % 2000;
                        if (withAmount >= 100 && withAmount >= 200 && withAmount >= 500 && withAmount < 2000)
                        {
                            withAmount = five_check(twok, withAmount);
                            if (withAmount >= 100 && withAmount >= 200 && withAmount < 500)
                            {
                                withAmount = two_check(twok, withAmount);
                            }
                        }
                    }
                }
            } while (withAmount != 0);
        }
        public int two_check(int twok, int withAmount)
        {
            twok = (int)withAmount / 200;
            Console.WriteLine("{0} Notes of 200", twok);
            withAmount = (int)withAmount % 200;
            return withAmount;
        }
        public int five_check(int twok, int withAmount)
        {
            twok = (int)withAmount / 500;
            Console.WriteLine("{0} Notes of 500", twok);
            withAmount = (int)withAmount % 500;
            return withAmount;
        }
        public void withDraw()
        {
            Atm a = new Atm();
            int ch = 0;
            Console.WriteLine("Enter the PIN");
            pin = Convert.ToInt32(Console.ReadLine());
            if (pin != sav_pin)
            {
                Console.WriteLine("Incorrect PIN");
            }
            else
            {
                Console.WriteLine("Enter the amount to withdraw");
                int withAmount = Convert.ToInt32(Console.ReadLine());
                if (withAmount % 100 == 0)
                {
                    ch = Acc_type();
                    switch (ch)
                    {
                        case 1:
                            if (withAmount > curr_balance)
                            {
                                Console.WriteLine("Withdraw Amount exceeds balance");
                            }
                            else
                            {
                                Amt(withAmount);
                                Console.WriteLine("Collect the Money and Card");
                                curr_balance = Math.Round((double)curr_balance - withAmount, 2);
                            }
                            break;
                        case 2:
                            if (withAmount > sav_balance)
                            {
                                Console.WriteLine("Withdraw Amount exceeds balance");
                            }
                            else
                            {
                                Amt(withAmount);
                                Console.WriteLine("Collect the Money and Card");
                                sav_balance = Math.Round((double)sav_balance - withAmount, 2);
                            }
                            break;
                        default:
                            Console.WriteLine("Enter valid choice");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Enter amount in multiple of 100");
                }
            }
        }
        public void choice()
        {
            int ch = 0;
            do
            {
                Console.WriteLine("1. Balance Check");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Pin Change");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Deposit");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter your choice");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        displayBal();
                        break;
                    case 2:
                        withDraw();
                        break;
                    case 3:
                        pinUpdate();
                        break;
                    case 4:
                        transfer();
                        break;
                    case 5:
                        deposit();
                        break;
                    default:
                        Console.WriteLine("Enter valid choice");
                        break;
                }
            } while (ch != 0);

        }
        public int Acc_type()
        {
            Console.WriteLine("Choose account type");
            Console.WriteLine("1. Current");
            Console.WriteLine("2. Savings");
            int choi = Convert.ToInt32(Console.ReadLine());
            return choi;
        }
    }
    public static class AtmMac
    {
        static void Main(string[] args)
        {
            Atm a = new Atm();
            a.choice();

        }
    }
}


