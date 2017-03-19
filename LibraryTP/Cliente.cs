using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryBO
{

    public enum TipoNumero
    {
        Telefone,
        Telemovel,
    }
    public enum TipoDespesa
    {
        Semanal,
        Bimestre,
        Mensal,
    }

    public enum EstadoCliente
    {
        Pendente,
        Normal,
        Eliminado,
    }

    public class Cliente
    {

        // 17-03-2017 ... Variaveis a mais rever se fazem falta!

        #region Estado

        string numTel;
        double saldo;
        //double despesaMes;
        string nome;
        double despesa;
        int numeroTel;
        int chamadaFixo; // para numeros com 6
        int chamadaMovel; // para numeros com 6
        double despesaMes;
        Operadora op;
        TipoNumero tipoNum;
        TipoDespesa tipoDes;
        EstadoCliente estCliente;

        #endregion

        #region Construtores

        public Cliente()
        {

        }
        public Cliente(string nomeCliente, string numTelefone, TipoNumero tipoN, TipoDespesa tipoD)
        {
            nome = nomeCliente;
            numTel = numTelefone;
            tipoNum = tipoN;
            
        }
        /// <summary>
        /// Cliente com servico movel 91 
        /// </summary>
        /// <param name="nomeCliente"></param>
        /// <param name="numTelefone"></param>
        /// <param name="saldoC"></param>
        public Cliente(string nomeCliente, string numTelefone, double saldoC)
        {
            nome = nomeCliente;
            numTel = numTelefone;
            saldo = saldoC;
            
        }

        #endregion

        #region Properties

        public int ChamadaFixo
        {
            get { return chamadaFixo; }
            set { chamadaFixo = value; }
        }
        public int ChamadaMovel
        {
            get { return chamadaMovel; }
            set { chamadaMovel = value; }
        }

        public double DespesaMes
        {
            get { return despesaMes; }
            set { despesaMes = value; }
        }
        

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
        public int NumeroTT
        {
            get { return numeroTel; }
            set { numeroTel = value; }
        }

        public TipoNumero GeneroNumero
        {
            get { return tipoNum; }
            set { tipoNum = value; }
        }
        public TipoDespesa TipoDespesaCliente
        {
            get { return tipoDes; }
            set { tipoDes = value; }
        }

        public EstadoCliente SituacaoCliente
        {
            get { return estCliente; }
            set { estCliente = value; }
        }
        
		public Operadora FidelizacaoCliente
		{
			get{ return op; }
			set{ op = value; }
		}

        #endregion

        #region Metodos

        

       
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

