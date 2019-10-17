﻿using System;

namespace AtmMachine
{
    class Atm
    {
        int sav_pin = 1234;
        public double sav_balance = new Random().Next(1000, 99999);
        public double curr_balance = new Random().Next(1000, 9999);
        public int t_amt = 0;
        public int t_acc = 0;
        public void displayBal()
        {
            int bal_ch = 0;
            Console.WriteLine("Choose account type");
            Console.WriteLine("1. Current");
            Console.WriteLine("2. Savings");
            bal_ch = Convert.ToInt32(Console.ReadLine());

            switch (bal_ch)
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
        public double deposit()
        {
            Console.WriteLine("Enter amount to be deposited");
            double d_amt = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Account type");
            Console.WriteLine("1. Current");
            Console.WriteLine("2. Savings");
            t_acc = Convert.ToInt32(Console.ReadLine());
            if (t_acc == 1)
            {
                curr_balance = Math.Round((double)curr_balance + d_amt, 2);
                Console.WriteLine("Deposited");
                return curr_balance;
            }
            else if (t_acc == 2)
            {
                sav_balance = Math.Round((double)sav_balance + d_amt, 2);
                Console.WriteLine("Deposited");
                return sav_balance;
            }
            else
            {
                Console.WriteLine("Incorrect choice");
                return curr_balance;
            }
        }
        public double transfer()
        {
            Console.WriteLine("Enter account number");
            long acc_no = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Amount");
            t_amt = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("From account type");
            Console.WriteLine("1. Current");
            Console.WriteLine("2. Savings");
            t_acc = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter PIN");
            int t_pin = Convert.ToInt32(Console.ReadLine());
            if (t_pin == sav_pin)
            {
                if (t_acc == 1 && t_amt <= curr_balance)
                {
                    curr_balance = Math.Round((double)curr_balance - t_amt, 2);
                    return curr_balance;
                }
                else if (t_acc == 2 && t_amt <= sav_balance)
                {
                    sav_balance = Math.Round((double)sav_balance - t_amt, 2);
                    return sav_balance;
                }
                else
                {
                    Console.WriteLine("Insufficient amount");
                    return curr_balance;
                }
            }
            else
                Console.WriteLine("Incorrect PIN");
            return sav_balance;
        }
        public void pinUpdate()
        {
            Console.WriteLine("Enter old PIN");
            int o_pin = Convert.ToInt32(Console.ReadLine());
            if (o_pin == sav_pin)
            {
                Console.WriteLine("Enter new PIN");
                sav_pin = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("PIN updated");
            }
            else
            {
                Console.WriteLine("Incorrect Pin");
            }
        }
        public double Amt(int withAmount)
        {
            int twok = 0;
            do
            {
                if (withAmount >= 100)
                {
                    if (withAmount >= 100 && withAmount < 200)
                    {
                        twok = (int)withAmount / 100;
                        Console.WriteLine("{0} Notes of 100", twok);
                        break;
                    }
                    else if (withAmount >= 200 && withAmount < 500)
                    {
                        twok = (int)withAmount / 200;
                        Console.WriteLine("{0} Notes of 200", twok);
                        withAmount = (int)withAmount % 200;
                    }
                    else if (withAmount >= 100 && withAmount >= 200 && withAmount >= 500 && withAmount < 2000)
                    {
                        twok = (int)withAmount / 500;
                        Console.WriteLine("{0} Notes of 500", twok);
                        withAmount = (int)withAmount % 500;
                        if (withAmount >= 100 && withAmount >= 200 && withAmount < 500)
                        {

                            twok = (int)withAmount / 200;
                            Console.WriteLine("{0} Notes of 200", twok);
                            withAmount = (int)withAmount % 200;
                        }
                    }
                    else if (withAmount >= 100 && withAmount >= 200 && withAmount >= 500 && withAmount >= 2000)
                    {
                        twok = (int)withAmount / 2000;
                        Console.WriteLine("{0} Notes of 2000", twok);
                        withAmount = (int)withAmount % 2000;
                        if (withAmount >= 100 && withAmount >= 200 && withAmount >= 500 && withAmount < 2000)
                        {
                            twok = (int)withAmount / 500;
                            Console.WriteLine("{0} Notes of 500", twok);
                            withAmount = (int)withAmount % 500;
                            if (withAmount >= 100 && withAmount >= 200 && withAmount < 500)
                            {

                                twok = (int)withAmount / 200;
                                Console.WriteLine("{0} Notes of 200", twok);
                                withAmount = (int)withAmount % 200;
                            }
                        }
                    }
                }
            } while (withAmount != 0);
            return curr_balance;
            return sav_balance;

        }
        public double withDraw()
        {
            Atm a = new Atm();
            int with_ch = 0;
            Console.WriteLine("Enter the PIN");
            int pin = Convert.ToInt32(Console.ReadLine());
            if (pin != sav_pin)
            {
                Console.WriteLine("Incorrect PIN");
                return curr_balance;
            }
            else
            {
                Console.WriteLine("Enter the amount to withdraw");
                int withAmount = Convert.ToInt32(Console.ReadLine());
                if (withAmount % 100 == 0)
                {
                    Console.WriteLine("Choose account type");
                    Console.WriteLine("1. Current");
                    Console.WriteLine("2. Savings");
                    with_ch = Convert.ToInt32(Console.ReadLine());
                    switch (with_ch)
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
                                return curr_balance;

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
                                return sav_balance;
                            }
                            break;
                        default:
                            Console.WriteLine("Enter valid choice");
                            return sav_balance;
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Enter amount in multiple of 100");
                    return curr_balance;
                }
            }
            return curr_balance;
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


