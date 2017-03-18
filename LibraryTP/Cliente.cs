using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryBO
{
    public class Cliente
    {

        // 17-03-2017 ... Variaveis a mais rever se fazem falta!

        #region Estado

        string numTel;
        double saldo;
        double despesaMes;
        string nome;
        double despesa;
        int chamadaMovel;
        int chamadaFixo;
        public Chamada[] registo;
		Operadora op;

        #endregion

        #region Construtores

        public Cliente()
        {
            nome = "Donald Trump";
            numTel = "918197035";
            saldo = 250;
            registo = new Chamada[0];
        }
        public Cliente(string a, string b)
        {
            nome = a;
            numTel = b;
            registo = new Chamada[0];
        }
        public Cliente(string a, string b, double c)
        {
            nome = a;
            numTel = b;
            saldo = c;
            registo = new Chamada[0];
        }

        #endregion

        #region Properties

        public string Nome
        {
            get { return (nome); }
            set { nome = value; }
        }
        public string NumTel
        {
            get { return (numTel); }
            set { numTel = value; }
        }
        public double Saldo
        {
            get { return (saldo); }
            set { saldo = value; }
        }
        public double Despesa
        {
            get { return (despesa); }
            set { despesa = value; }
        }
        public double Despesames
        {
            get { return (despesaMes); }
            set { despesaMes = value; }
        }
        public int ChamadaMovel
        {
            get { return (chamadaMovel); }
            set { chamadaMovel = value; }
        }
        public int ChamadaFixo
        {
            get { return (chamadaFixo); }
            set { chamadaFixo = value; }
        }
        public Chamada[] Registo
        {
            get { return (registo); }
            set { registo = value; }
        }

		public Operadora FidelizacaoCliente
		{
			get{ return op; }
			set{ op = value; }
		}

        #endregion

        #region Metodos

        public static bool criarVariosClientes(Cliente[] a)
        {
            Cliente[] b;
            Console.WriteLine("Insira o numero de clientes que pretende inserir.");
            int numClientes = int.Parse(Console.ReadLine());
            if(numClientes<1 || numClientes > 20)
            {
                Console.WriteLine("Numero for dos limites, p.f.f reinsira-o");
                numClientes = int.Parse(Console.ReadLine());
            }
            b = new Cliente[a.Length + numClientes];
            for(int i = 0; i < a.Length; i++)
            {
                b[i] = a[i];
            }
            for(int i = a.Length; i < b.Length; i++)
            {
                string nomeCliente;
                string numCliente;
                Console.WriteLine("Insira o nome do Cliente");
                nomeCliente = Console.ReadLine();
                if (checkNome(nomeCliente) == false || checkNomeArray(nomeCliente, a) == false)
                {
                    Console.WriteLine("Nome mal inserido, p.f.f reinsira-o");
                    nomeCliente = Console.ReadLine();
                }                
                Console.WriteLine("Insira o numero do Cliente");
                numCliente = Console.ReadLine();
                if(checkNumArray(numCliente,a)==false)
                {
                    Console.WriteLine("Numero mal inserido");
                    Console.WriteLine("Insira o numero do Cliente");
                    numCliente = Console.ReadLine();
                }
                Console.WriteLine("Pretende inserir saldo no dispositivo de comunicacao do cliente? 1-Sim;2-Nao");
                int escolhaSaldo = int.Parse(Console.ReadLine());
                if(escolhaSaldo<1 || escolhaSaldo > 2) { Console.WriteLine("Reinsira os dados p.f.f");escolhaSaldo = int.Parse(Console.ReadLine()); }
                if (escolhaSaldo == 1)
                {
                    Console.WriteLine("Insira o saldo desejado p.f.f");
                    double saldoCliente = double.Parse(Console.ReadLine());
                    if(saldoCliente<1 || saldoCliente > 250) { Console.WriteLine("Reinsira os dados p.f.f"); saldoCliente = double.Parse(Console.ReadLine()); }
                    b[i] = new Cliente(nomeCliente, numCliente, saldoCliente);
                }
                else
                {
                    b[i] = new Cliente(nomeCliente, numCliente);
                }
                Console.WriteLine("Cliente {0} com o num {1} foi bem inserido", b[i].Nome, b[i].NumTel);
            }
            a = b;
            return true;
        }
        public static bool adicionarCliente(Cliente p, Cliente[] a)
        {
            int i;
            for (i = 0; i<a.Length ; i++)
            {
                if (a[i].Nome == p.Nome) return false;
                if (a[i].NumTel == p.NumTel) return false;
            }
            Cliente[] c = new Cliente[a.Length + 1];
            for(int q = 0; q < a.Length; q++)
            {
                c[q] = a[q];
            }            
            c[i] = p;
            a = c;
            return true;
        }
        public static bool removerCliente(Cliente p, Cliente[] a)
        {
            Cliente[] b = new Cliente[a.Length - 1];
            int contador = 0;
            foreach(Cliente x in a)
            {                
                if (p.Nome == x.Nome)
                {
                    continue;
                }
                else
                {
                   b[contador] = x;
                }
                contador++;
            }
            a = b;
            return true;
        }
        public static Cliente adicionarSaldo(Cliente p)
        {
            int saldoTemp;
            Console.WriteLine("Quanto saldo pretende inserir?");
            bool saldoEscolha = int.TryParse(Console.ReadLine(),out saldoTemp);            
            if (saldoEscolha == false)
            {
                Console.WriteLine("Dados mal inseridos, por favor reinsira-os");
                saldoEscolha = int.TryParse(Console.ReadLine(), out saldoTemp);
            }
            else if(saldoTemp<0 && saldoTemp>100)
            {
                Console.WriteLine("Dados mal inseridos, maximo de 100 euros para carregar.");                
                Console.WriteLine("Insira um valor correto: ");
                saldoEscolha = int.TryParse(Console.ReadLine(), out saldoTemp);
                if (saldoEscolha == false)
                {
                    Console.WriteLine("Dados mal inseridos, por favor reinsira-os");
                    saldoEscolha = int.TryParse(Console.ReadLine(), out saldoTemp);
                }
            }
            p.Saldo = p.Saldo + saldoTemp;
            return p;
        }
        public static bool pagarMensalidade(Cliente p)
        {
            Console.WriteLine("Para pagar a mensalidade por favor pague 19.99");
            Console.WriteLine("Pretende inserir dinheiro, ou pagar com o saldo?");
            if (p.Saldo < 19.99)
            {
                double dinheiroEmFalta;
                dinheiroEmFalta = 19.99 - p.Saldo;
                Console.WriteLine("Saldo: {0}; Falta {1} euros para pagar o mes.",p.Saldo,dinheiroEmFalta);
                adicionarSaldo(p);
            }
            else { Console.WriteLine("Saldo: {0}", p.Saldo); }
            Console.WriteLine("\nForam deduzidos 19.99 do seu saldo para pagar a mensalidade");
            Console.WriteLine("Tem {0} de saldo restante", p.Saldo);
            p.chamadaFixo = 4000;
            p.ChamadaMovel = 3000;
            return true;
            
        }
        public static int procurarCliente(Cliente[] p)
        {            
            int escolha;
            int numPessoa;
            Console.WriteLine("Insira os dados que conhece da pessoa:");
            Console.WriteLine("\tNumero - 1");
            Console.WriteLine("\tNome - 2");
            bool checkEscolha = int.TryParse(Console.ReadLine(), out escolha);
            if (checkEscolha == false)
            {
                Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os.");
                checkEscolha = int.TryParse(Console.ReadLine(), out escolha);
            }
            if(escolha<1 && escolha > 2)
            {
                Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os.");
                checkEscolha = int.TryParse(Console.ReadLine(), out escolha);
                if (checkEscolha == false)
                {
                    Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os.");
                    checkEscolha = int.TryParse(Console.ReadLine(), out escolha);
                }
            }
            if (escolha == 1)
            {
                int escolha1;
                Console.WriteLine("Insira o numero da pessoa, ou parte:");
                string dadosConhecidos1 = Console.ReadLine();
                for (int i = 0; i < p.Length; i++)
                {
                    if (p[i].NumTel.Contains(dadosConhecidos1))
                    {
                        Console.WriteLine("{0} - {1} , {2}", i, p[i].Nome, p[i].NumTel);
                    }
                }
                Console.WriteLine("Conseguiu encontrar a pessoa?");
                Console.WriteLine("1 - Inserir o numero correspondente a pessoa");
                Console.WriteLine("2 - Escpecificar melhor os dados conhecidos, para procurar de novo");
                bool checkEscolha1 = int.TryParse(Console.ReadLine(), out escolha1);
                if (checkEscolha1 == false)
                {
                    Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os.");
                    checkEscolha1 = int.TryParse(Console.ReadLine(), out escolha1);
                }
                if (escolha1 < 1 && escolha1 > 2)
                {
                    Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os.");
                    checkEscolha1 = int.TryParse(Console.ReadLine(), out escolha1);
                    if (checkEscolha1 == false)
                    {
                        Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os.");
                        checkEscolha1 = int.TryParse(Console.ReadLine(), out escolha1);
                    }
                }
                if (escolha1 == 1)
                {                    
                    Console.WriteLine("Insira o numero:");
                    bool checkNumPessoa = int.TryParse(Console.ReadLine(), out numPessoa);
                    if (checkNumPessoa == false)
                    {
                        Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os");
                        checkNumPessoa = int.TryParse(Console.ReadLine(), out numPessoa);
                    }
                    if(numPessoa<1 && numPessoa > p.Length)
                    {
                        Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os");
                        checkNumPessoa = int.TryParse(Console.ReadLine(), out numPessoa);
                        if (checkNumPessoa == false)                                                                   
                        {
                            Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os");
                            checkNumPessoa = int.TryParse(Console.ReadLine(), out numPessoa);
                        }
                    }
                    return numPessoa;                  
                }
                else { numPessoa = -1;return numPessoa; }
            }
            else if (escolha == 2)
            {
                int escolha1;
                Console.WriteLine("Insira o nome da pessoa, ou parte:");
                string dadosConhecidos1 = Console.ReadLine();
                Console.WriteLine(dadosConhecidos1);
                Console.WriteLine(p.Length);
                for (int i = 0; i < p.Length; i++)
                {                    
                    if (p[i].Nome.Contains(dadosConhecidos1))
                    {
                        Console.WriteLine("{0} - {1} , {2}", i, p[i].Nome, p[i].NumTel);
                    }
                }
                Console.WriteLine("Conseguiu encontrar a pessoa?");
                Console.WriteLine("1 - Inserir o numero correspondente a pessoa");
                Console.WriteLine("2 - Especificar melhor os dados conhecidos, para procurar de novo");
                bool checkEscolha1 = int.TryParse(Console.ReadLine(), out escolha1);
                if (checkEscolha1 == false)
                {
                    Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os.");
                    checkEscolha1 = int.TryParse(Console.ReadLine(), out escolha1);
                }
                if (escolha1 < 1 && escolha1 > 2)
                {
                    Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os.");
                    checkEscolha1 = int.TryParse(Console.ReadLine(), out escolha1);
                    if (checkEscolha1 == false)
                    {
                        Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os.");
                        checkEscolha1 = int.TryParse(Console.ReadLine(), out escolha1);
                    }
                }
                if (escolha1 == 1)
                {                    
                    Console.WriteLine("Insira o numero:");
                    bool checkNumPessoa = int.TryParse(Console.ReadLine(), out numPessoa);
                    if (checkNumPessoa == false)
                    {
                        Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os");
                        checkNumPessoa = int.TryParse(Console.ReadLine(), out numPessoa);
                    }
                    if (numPessoa < 1 && numPessoa > p.Length)
                    {
                        Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os");
                        checkNumPessoa = int.TryParse(Console.ReadLine(), out numPessoa);
                        if (checkNumPessoa == false)
                        {
                            Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os");
                            checkNumPessoa = int.TryParse(Console.ReadLine(), out numPessoa);
                        }
                    }
                    return numPessoa;                   
                }
                else
                { numPessoa = -1; return numPessoa; }
            }
            else { numPessoa = -1;return numPessoa; }            
        }
        public static bool pagarMes(Cliente p)
        {
            int numOperador;
            Console.WriteLine("Cliente : {0} \nNumTel: {1}", p.Nome, p.NumTel);
            Console.WriteLine("Saldo:{0} \nDespesa:{1}", p.Saldo, p.Despesa);
            numOperador = int.Parse(p.Nome.Substring(1, 1));
            switch (numOperador)
            {
                case 1:
                    int escolha = 0;
                    if (p.Despesa > 0)
                    {                        
                        Console.WriteLine("Tem uma divida cerca de : {0}", p.Despesa);
                        Console.WriteLine("Pretende pagar: ");
                        Console.WriteLine("1 - Sim;\n2 - Nao");
                        bool checkEscolha = int.TryParse(Console.ReadLine(), out escolha);
                        if (checkEscolha == false)
                        {
                            Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os");
                            checkEscolha = int.TryParse(Console.ReadLine(), out escolha);
                        }
                        if(escolha<1 && escolha > 2)
                        {
                            Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os");
                            checkEscolha = int.TryParse(Console.ReadLine(), out escolha);
                            if (checkEscolha == false)
                            {
                                Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os");
                                checkEscolha = int.TryParse(Console.ReadLine(), out escolha);
                            }
                        }
                        if (escolha == 1)
                        {
                            adicionarSaldo(p);
                            pagarMes(p);
                        }
                        else { break; }
                    }
                    else
                    {
                        Console.WriteLine("Nao tem divida");
                    }
                    break;
                case 3:
                    int escolha1 = 0;
                    if (p.Despesa > 0)
                    {
                        Console.WriteLine("Tem uma divida cerca de : {0}", p.Despesa);
                        Console.WriteLine("Pretende pagar: ");
                        Console.WriteLine("1 - Sim;\n2 - Nao");
                        bool checkEscolha = int.TryParse(Console.ReadLine(), out escolha1);
                        if (checkEscolha == false)
                        {
                            Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os");
                            checkEscolha = int.TryParse(Console.ReadLine(), out escolha1);
                        }
                        if (escolha1 < 1 && escolha1 > 2)
                        {
                            Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os");
                            checkEscolha = int.TryParse(Console.ReadLine(), out escolha1);
                            if (checkEscolha == false)
                            {
                                Console.WriteLine("Dados mal inseridos,p.f.f reinsira-os");
                                checkEscolha = int.TryParse(Console.ReadLine(), out escolha1);
                            }
                        }
                        if (escolha1 == 1)
                        {
                            adicionarSaldo(p);
                            pagarMes(p);
                        }
                        else { break; }
                    }
                    else
                    {
                        Console.WriteLine("Nao tem divida");
                    }
                    break;
                case 6:
                    pagarMensalidade(p);
                    break;
                default:break;                    
            }
            return true;
        }   
        public static bool checkNome(string nome)
        {
            if (nome.Any(c => !Char.IsLetter(c)))                 //ve se o nome nao tem numeros ou carateres especiais
            {
                return false;
            }
            return true;
        }
        public static bool checkNomeArray(string nome,Cliente[] b)
        {
            for(int i = 0; i < b.Length; i++)
            {
                if (nome == b[i].Nome) return false;
            }            
            return true;
        } 
        public static bool checkNum(string num)
        {
            if (num.Length != 9) return false;            
            if (num.Substring(0, 1) != "2" || num.Substring(0, 1) != "9") return false;
            if (num.Substring(0, 1) == "9")
            {
                if (num.Substring(1, 1) != "1" || num.Substring(1, 1) != "3" || num.Substring(1, 1) != "6") return false;
            }
            if (num.Any(c => !Char.IsDigit(c))) return false;
            return true;
        }
        public static bool checkNumArray(string num,Cliente[] b)
        {           
            if (checkNum(num) == false)
            {
                Console.WriteLine("Numero mal inserido, p.f.f reinisira-o");
                num = Console.ReadLine();
            }
            for (int i = 0; i < b.Length; i++)
            {                
                if (num == b[i].NumTel) return false;                
            }
            return true;
        }
        public override string ToString()  
        // override "reescrita" do metodo do C# ( ToString() )
        {            
            return base.ToString() + "- Nome: " + Nome.ToString()+"; Numero: "+NumTel.ToString() + "; Saldo: "+Saldo.ToString();
        }
    }
        
        #endregion
    }

