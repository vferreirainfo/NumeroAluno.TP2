using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LibraryTP
{
    public class Chamada:Cliente
    {
        #region Estado

        int duracao;
        int mes;
        int dia;
        double custo;
        Cliente callNumber, recNumber;

        #endregion

        #region Construtores

        public Chamada()
        {
            mes = 1;
            dia = 25;
            custo = 0.01;
            Cliente p = new Cliente();
            Cliente c = new Cliente("Melanie", "969539135");
            Console.WriteLine("A contactar Melanie");
            Console.WriteLine("...................");
            Console.WriteLine("      .....        ");
            Console.WriteLine("Fim da chamada");
            duracao = 123;
            p.Saldo = p.Saldo - 0.01;
        }
        public Chamada(Cliente caller,Cliente receiver,int mesc,int diac)
        {
            #region Telemovel
            if (caller.NumTel.Substring(0, 1) == "9")
            {
                #region Telemovel-91

                if(caller.NumTel.Substring(1, 1) == "1")
                {
                    if(receiver.NumTel.Substring(0, 1) == "9")
                    {
                        if (caller.Saldo >= 0.05)
                        {                            
                            mes = mesc;
                            dia = diac;
                            custo = 0.05;
                            duracao = contarDuracao(caller, receiver);
                            caller.Saldo = caller.Saldo - 0.05;
                        }
                        else
                        {
                            mes = mesc;
                            dia = diac;
                            custo = 0.05;
                            duracao = contarDuracao(caller, receiver);
                            caller.Despesa = caller.Despesa + 0.05;
                        }
                    }                    
                    else if (receiver.NumTel.Substring(0, 1) == "2")
                    {
                        if (caller.Saldo >= 0.15)
                        {
                            mes = mesc;
                            dia = diac;
                            custo = 0.15;
                            duracao = contarDuracao(caller, receiver);
                            caller.Saldo = caller.Saldo - 0.15;
                        }
                        else
                        {
                            mes = mesc;
                            dia = diac;
                            custo = 0.15;
                            duracao = contarDuracao(caller, receiver);
                            caller.Despesa = caller.Despesa + 0.15;
                        }                        
                    }                  
                }
                #endregion

                #region Telemovel-93

                else if (caller.NumTel.Substring(1, 1) == "3")
                {
                    if (receiver.NumTel.Substring(0, 1) == "9")
                    {
                        mes = mesc;
                        dia = diac;
                        custo = 0.80;
                        duracao = contarDuracao(caller, receiver);
                        caller.Despesames = caller.Despesames + 0.80;
                    }
                    else if (receiver.NumTel.Substring(0, 1) == "2")
                    {
                        mes = mesc;
                        dia = diac;
                        custo = 0.17;
                        duracao = contarDuracao(caller, receiver);
                        caller.Despesames = caller.Despesames + 0.17;
                    }
                }

                #endregion

                #region Telemovel-96

                else if (caller.NumTel.Substring(1, 1) == "6")
                {
                    if (receiver.NumTel.Substring(0, 1) == "9")
                    {                        
                            mes = mesc;
                            dia = diac;
                            duracao = contarDuracao(caller, receiver);
                            caller.ChamadaMovel = caller.ChamadaMovel - 1;                        
                    }
                    else if (receiver.NumTel.Substring(0, 1) == "2")
                    {                        
                            mes = mesc;
                            dia = diac;
                            duracao = contarDuracao(caller, receiver);
                            caller.ChamadaFixo = caller.ChamadaFixo - 1;
                           
                    }
                }
                #endregion
            }
            #endregion

            #region Telefone

            else if (caller.NumTel.Substring(0,1) == "2")
            {
                if (receiver.NumTel.Substring(0, 1) == "9")
                {
                    mes = mesc;
                    dia = diac;
                    custo = 0.1;
                    duracao = contarDuracao(caller, receiver);
                    caller.Despesames = caller.Despesames + 0.1;
                }
                else if (receiver.NumTel.Substring(0, 1) == "2")
                {
                    mes = mesc;
                    dia = diac;
                    custo = 0;
                    duracao = contarDuracao(caller, receiver);
                }
            }
            #endregion                       

            callNumber = caller;
            recNumber = receiver;            
        }
        public Chamada(Cliente caller,Cliente receiver)
        {
            #region Telemovel
            if (caller.NumTel.Substring(0, 1) == "9")
            {
                #region Telemovel-91

                if (caller.NumTel.Substring(1, 1) == "1")
                {
                    if (receiver.NumTel.Substring(0, 1) == "9")
                    {
                        if (caller.Saldo >= 0.05)
                        {
                            mes = 1;
                            dia = 25;
                            custo = 0.05;
                            duracao = contarDuracao(caller, receiver);
                            caller.Saldo = caller.Saldo - 0.05;
                        }
                        else
                        {
                            mes = 1;
                            dia = 5;
                            custo = 0.05;
                            duracao = contarDuracao(caller, receiver);
                            caller.Despesa = caller.Despesa + 0.05;
                        }
                    }
                    else if (receiver.NumTel.Substring(0, 1) == "2")
                    {
                        if (caller.Saldo >= 0.15)
                        {
                            mes = 1;
                            dia = 5;
                            custo = 0.15;
                            duracao = contarDuracao(caller, receiver);
                            caller.Saldo = caller.Saldo - 0.15;
                        }
                        else
                        {
                            mes = 1;
                            dia = 5;
                            custo = 0.15;
                            duracao = contarDuracao(caller, receiver);
                            caller.Despesa = caller.Despesa + 0.15;                            
                        }
                    }
                }
                #endregion

                #region Telemovel-93

                else if (caller.NumTel.Substring(1, 1) == "3")
                {
                    if (receiver.NumTel.Substring(0, 1) == "9")
                    {
                        mes = 1;
                        dia = 5;
                        custo = 0.80;
                        duracao = contarDuracao(caller, receiver);
                        caller.Despesames = caller.Despesames + 0.80;
                    }
                    else if (receiver.NumTel.Substring(0, 1) == "2")
                    {
                        mes = 1;
                        dia = 5;
                        custo = 0.17;
                        duracao = contarDuracao(caller, receiver);
                        caller.Despesames = caller.Despesames + 0.17;
                    }
                }

                #endregion

                #region Telemovel-96

                else if (caller.NumTel.Substring(1, 1) == "6")
                {
                    if (receiver.NumTel.Substring(0, 1) == "9")
                    {
                        mes = 1;
                        dia = 5;
                        duracao = contarDuracao(caller, receiver);
                        caller.ChamadaMovel = caller.ChamadaMovel - 1;
                    }
                    else if (receiver.NumTel.Substring(0, 1) == "2")
                    {
                        mes = 1;
                        dia = 5;
                        duracao = contarDuracao(caller, receiver);
                        caller.ChamadaFixo = caller.ChamadaFixo - 1;
                    }
                }
                #endregion
            }
            #endregion
            #region Telefone

            else if (caller.NumTel.Substring(0, 1) == "2")
            {
                if (receiver.NumTel.Substring(0, 1) == "9")
                {
                    mes = 1;
                    dia = 5;
                    custo = 0.1;
                    duracao = contarDuracao(caller, receiver);
                    caller.Despesames = caller.Despesames + 0.1;
                }
                else if (receiver.NumTel.Substring(0, 1) == "2")
                {
                    mes = 1;
                    dia = 5;
                    custo = 0;
                    duracao = contarDuracao(caller, receiver);
                }
            }

            #endregion

            callNumber = caller;
            recNumber = receiver;
        }
    
        #endregion

        #region Properties

        public int Duracao
        {
            get { return (duracao); }
            set { duracao = value; }
        }
        public int Mes
        {
            get { return (mes); }
            set { mes = value; }
        }
        public int Dia
        {
            get { return (dia); }
            set { dia = value; }
        }
        public double Custo
        {
            get { return (custo); }
            set { custo = value; }
        }
        public Cliente Callnumber
        {
            get { return (callNumber); }
            set { callNumber = value; }
        }
        public Cliente Recnumber
        {
            get { return (recNumber); }
            set { recNumber = value; }
        }
        #endregion

        #region Metodos

        public static bool mostrarChamadas(Chamada[] p)
    {
        for(int i = 0; i < p.Length; i++)
        {
                if (p[i].Recnumber == null || p[i].Mes==0)
                {
                    Console.WriteLine("Chamada nao concretizada");
                }
                else
                {
                    string mes1 = getMonth(p[i].Mes);
                    Console.WriteLine("Chamada {0}: \n\t Mes: {1} ", i, mes1);
                    Console.WriteLine("\t Dia: {0}", p[i].Dia);
                    Console.WriteLine("Chamador: ");
                    Console.WriteLine("\tNome: {0} ; \n\tNumTel: {1}", p[i].Callnumber.Nome, p[i].Callnumber.NumTel);
                    Console.WriteLine("Pessoa contactada: ");
                    Console.WriteLine("\tNome: {0};\n\tNumTel: {1}", p[i].Recnumber.Nome, p[i].Recnumber.NumTel);
                    Console.WriteLine("Informacao da chamada");
                    Console.WriteLine("\tDuracao: {0} ; \n\tCusto: {1}", p[i].Duracao, p[i].Custo);
                }
                
        }            
            return true;
    }
        public static string getMonth(int mes)
    {
        string mesNome = string.Empty;
        switch (mes)
        {
            case 1:
                mesNome = "Janeiro";
                break;
            case 2:
                mesNome = "Fevereiro";
                break;
            case 3:
                mesNome = "Marco";
                break;
            case 4:
                mesNome = "Abril";
                break;
            case 5:
                mesNome = "Maio";
                break;
            case 6:
                mesNome = "Junho";
                break;
            case 7:
                mesNome = "Julho";
                break;
            case 8:
                mesNome = "Agosto";
                break;
            case 9:
                mesNome = "Setembro";
                break;
            case 10:
                mesNome = "Outubro";
                break;
            case 11:
                mesNome = "Novembro";
                break;
            case 12:
                mesNome = "Dezembro";
                break;
        }
        return (mesNome);

        }
        public static bool fazerCham(Cliente p,Cliente[] b)
        {
            int dia1;
            int escolha;
            int x = 0;
            int mes = 0;
            int dia = 0;
            Array.Resize(ref p.registo, p.registo.Length + 1);
            Console.WriteLine("Para realizar a chamada, p.f.f insira os dados:");
            mes = getMes();
            #region CheckDiaValido          
            switch (mes)
            {
                case 1:
                    dia = getDia();
                    break;
                case 2:
                    dia1 = getDia();
                    if (dia1 > 28)
                    {
                        Console.WriteLine("Dados mal inseridos,por favor reinsira-os:");
                        dia1 = getDia();
                    }
                    dia = dia1;
                    break;
                case 3:
                    dia = getDia();
                    break;
                case 4:
                    dia1 = getDia();
                    if (dia1 > 30)
                    {
                        Console.WriteLine("Dados mal inseridos,por favor reinsira-os:");
                        dia1 = getDia();
                    }
                    dia = dia1;
                    break;
                case 5:
                    dia = getDia();
                    break;
                case 6:
                    dia1 = getDia();
                    if (dia1 > 30)
                    {
                        Console.WriteLine("Dados mal inseridos,por favor reinsira-os:");
                        dia1 = getDia();
                    }
                    dia = dia1;
                    break;
                case 7:
                    dia = getDia();
                    break;
                case 8:
                    dia = getDia();                    
                    break;
                case 9:
                    dia1 = getDia();
                    if (dia1 > 30)
                    {
                        Console.WriteLine("Dados mal inseridos,por favor reinsira-os:");
                        dia1 = getDia();
                    }
                    dia = dia1;
                    break;
                case 10:
                    dia = getDia();
                    break;
                case 11:
                    dia1 = getDia();
                    if (dia1 > 30)
                    {
                        Console.WriteLine("Dados mal inseridos,por favor reinsira-os:");
                        dia1 = getDia();
                    }
                    dia = dia1;
                    break;
                case 12:
                    dia = getDia();
                    break;
                default:
                    break;
            }
            #endregion  
            Console.WriteLine("Sabe o numero  quem vai telefonar?");
            Console.WriteLine("\t1-Procurar pelo numero;");
            Console.WriteLine("\t2-Introduzir o numero de telefone do contactado");
            bool resultadoCheck = int.TryParse(Console.ReadLine(), out escolha);
            if (resultadoCheck == false) { Console.WriteLine("Dados mal inseridos, reinsira-os:");resultadoCheck = int.TryParse(Console.ReadLine(), out escolha); }
            if(escolha<1 && escolha > 2)
            { Console.WriteLine("Dados mal inseridos, reinsira-os:");
                resultadoCheck = int.TryParse(Console.ReadLine(), out escolha);
                if (resultadoCheck == false) { Console.WriteLine("Dados mal inseridos, reinsira-os:"); resultadoCheck = int.TryParse(Console.ReadLine(), out escolha); }
            }
            if (escolha == 1)
            {
                int numPessoa;        
                numPessoa = procurarCliente(b);
                x = numPessoa;
            }
            else if (escolha == 2)
            {
                int numPessoa;      
                Console.WriteLine("Escolheu introduzir o numero da pessoa que vai telefonar");
                bool checkNumPessoa = int.TryParse(Console.ReadLine(), out numPessoa);
                if (checkNumPessoa == false) { Console.WriteLine("Dados mal inseridos, reinsira-os:"); checkNumPessoa = int.TryParse(Console.ReadLine(), out numPessoa); }
                if (numPessoa < 1 && numPessoa > b.Length)
                {
                    Console.WriteLine("Dados mal inseridos, reinsira-os:");
                    checkNumPessoa = int.TryParse(Console.ReadLine(), out numPessoa);
                    if (resultadoCheck == false) { Console.WriteLine("Dados mal inseridos, reinsira-os:"); checkNumPessoa = int.TryParse(Console.ReadLine(), out numPessoa); }
                }
                x = numPessoa;
            }            
            p.Registo[p.Registo.Length - 1] = new Chamada(p, b[x], mes, dia);
            return true;
        }
        public static bool apagarCham(Cliente p,int numChamada)
        {
            Cliente b = new Cliente(p.Nome, p.NumTel, p.Saldo);                                    
            int contador = 0;           
            foreach(Chamada x in p.Registo)
            {
                if (p.Registo[numChamada].Duracao<1 || p.Registo[numChamada]!=null || p.Registo[numChamada].Mes<1)
                {
                    continue;
                }
                else
                {
                    b.Registo[contador] = x;
                }
                contador++;
            }
            return true;
        }
        public static int getMes()
        {
            int mes;
            Console.WriteLine("\tMes: ");
            bool resultado = int.TryParse(Console.ReadLine(), out mes);
            if (resultado == false)
            {
                Console.WriteLine("Dados mal inseridos, por favor reinsira-os");
                resultado = int.TryParse(Console.ReadLine(), out mes);
            }
            else if (mes < 1 && mes > 12)
            {
                Console.WriteLine("Dados mal inseridos, por favor reinsira-os");
                resultado = int.TryParse(Console.ReadLine(), out mes);
                if (resultado == false)
                {
                    Console.WriteLine("Dados mal inseridos, por favor reinsira-os");
                    resultado = int.TryParse(Console.ReadLine(), out mes);
                }
            }
            return mes;
        }
        public static int getDia()
        {
            int dia;
            Console.WriteLine("\tDia: ");
            bool resultado = int.TryParse(Console.ReadLine(), out dia);
            if (resultado == false)
            {
                Console.WriteLine("Dados mal inseridos, por favor reinsira-os");
                resultado = int.TryParse(Console.ReadLine(), out dia);
            }
            else if (dia < 1 && dia > 31)
            {
                Console.WriteLine("Dados mal inseridos, por favor reinsira-os");
                resultado = int.TryParse(Console.ReadLine(), out dia);
                if (resultado == false)
                {
                    Console.WriteLine("Dados mal inseridos, por favor reinsira-os");
                    resultado = int.TryParse(Console.ReadLine(), out dia);
                }
            }
            return dia;
        }
        public static int contarDuracao(Cliente caller,Cliente receiver)
        {
            int duracao;
            Console.WriteLine("A chamar {0} - {1} ...", receiver.NumTel, receiver.Nome);
            Console.WriteLine(".....................");
            Console.WriteLine(".....................");
            Console.WriteLine("Prima qualquer tecla para acabar a chamada");
            Console.Read();
            Console.WriteLine("Quanto tempo demorou a chamada? (em segundos)");
            bool resultado = int.TryParse(Console.ReadLine(), out duracao);
            if (resultado == false)
            {
                Console.WriteLine("Dados mal inseridos, por favor reinsira-os");
                resultado = int.TryParse(Console.ReadLine(), out duracao);
            }
            return duracao;
        }
        public override string ToString()
        {
            return base.ToString() + "\tMES: " + Mes.ToString() + "\tDIA: " + Dia.ToString() + ":\nCaller info:\n\tNome: " + Callnumber.Nome.ToString() + "\tNumero: " + Callnumber.NumTel.ToString() + "\nReceiver info:\n\tNome: " + Recnumber.Nome.ToString() + "\tNumero: " + Recnumber.NumTel.ToString()+"\nCusto: "+Custo.ToString()+"Duracao: "+Duracao.ToString();
        }
        
    }

        #endregion
    }
