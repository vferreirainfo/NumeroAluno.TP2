using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LibraryBO
{

    public enum PlanoChamadaIlimitado
    {
        chamadaFixa,
        chamadaMovel,
    }

    public enum EstadoChamada
    {
        Suspensa,
        CaixaCorreio,
        Efetuada,
        Eliminada,
        Escutada,
    }

    public class Chamada:Cliente 
    {


    

        #region Estado

        static TimeSpan duracao; // para guardar duracao entre DateTime A e B (Tempo em horas/minutos/seg)
        
        
        //static int mes; // MODIFIQUEI MES E DIA
        //static int dia;
        static double custo;
        Cliente callNumber, recNumber;
		static TimeSpan duration; // remover!!
		static DateTime dataIncioChamada, dataFimChamada; // data e hora respetivamente ... 
        PlanoChamadaIlimitado genChamada; // Apenas para os numeros com "6"
        EstadoChamada situacaoCorrenteCh;    
            
        // O dia, mes, ano (hora e minuto) inseridos serão mais a frente filtrados e verificados ... 
        //smpre usando como referencia as variaveis de DateTime


        #endregion

        #region Construtores

        /// <summary>
        ///       /// É suposto uma chamada ter uma Data (incial), Data (Final), Cliente 1, e Cliente 2 
        /// </summary>
        /// <param name="primeiroCliente">O cliente que liga</param>
        /// <param name="segCliente">O cliente que atende</param>
        /// <param name="primeiraDtFornecida">A data que é registada quando o "primeiro cliente" faz a chamada</param>
        /// <param name="secDtFornecida">A data que é registada quando um deles termina a chamada</param>
        public Chamada(Cliente primeiroCliente, Cliente segCliente, DateTime primeiraDtFornecida, DateTime secDtFornecida)
        {
            callNumber = primeiroCliente;
            recNumber = segCliente;
            dataIncioChamada = primeiraDtFornecida;
            dataFimChamada = secDtFornecida;   
        }

  




        // Buscar metodo original ao trabalho original

        /*    
		public static bool AdicionaCustoChamada(Cliente caller,Cliente receiver)
        {
            #region Telemovel
            if (caller.NumTel.Substring(0, 1) == "9")
            {
                #region Telemovel-91

                if (caller.NumTel.Substring(1, 1) == "1")
                {
					
					if (receiver.NumTel.Substring(0, 1) == "9" && receiver.NumTel.Substring(1, 1) == "1")
                    {
						receiver.FidelizacaoCliente.NomeOperadora=caller.FidelizacaoCliente.NomeOperadora;

						//set operadora
                        if (caller.Saldo >= 0.05)
                        {
                            //mes = 1;
                            //dia = 25;
                            custo = 0.05;
                            //duracao = contarDuracao(caller, receiver);
                            caller.Saldo = caller.Saldo - 0.05;
                        }
                        else //??
                        {
                            //mes = 1;
                            //dia = 5;
                            custo = 0.05;
                            //duracao = contarDuracao(caller, receiver);
                            caller.Despesa = caller.Despesa + 0.05;
                        }
                    }
					else if(receiver.NumTel.Substring(0, 1) == "9" && receiver.NumTel.Substring(1, 1) == "2")
					{

						//right there
						//set operadora
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
					else if(receiver.NumTel.Substring(0, 1) == "9" && receiver.NumTel.Substring(1, 1) == "3")
					{

						//right there
						//set operadora
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
					if (receiver.NumTel.Substring(0, 1) == "9" && receiver.NumTel.Substring(0, 1) == "1") // se receiver ==91
                    {

						//nao existe necessidade de verificar saldo??
                        mes = 1;
                        dia = 5;
                        custo = 0.80;
                        //duracao = contarDuracao(caller, receiver);
                        caller.Despesames = caller.Despesames + 0.80;
                    }
					else if (receiver.NumTel.Substring(0, 1) == "9" && receiver.NumTel.Substring(0, 1) == "2") // se receiver == 92
					{
						mes = 1;
						dia = 5;
						custo = 0.80;
						//duracao = contarDuracao(caller, receiver);
						caller.Despesames = caller.Despesames + 0.80;
					}
					else if (receiver.NumTel.Substring(0, 1) == "9" && receiver.NumTel.Substring(0, 1) == "3") // se receiver == 93
					{
						mes = 1;
						dia = 5;
						custo = 0.80;
						//duracao = contarDuracao(caller, receiver);
						caller.Despesames = caller.Despesames + 0.80;
					}
					else if (receiver.NumTel.Substring(0, 1) == "2")
                    {
                        mes = 1;
                        dia = 5;
                        custo = 0.17;
                        //duracao = contarDuracao(caller, receiver);
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

//            callNumber = caller;
  //          recNumber = receiver;
        }
    */
        #endregion

        #region Properties

        public TimeSpan Duracao
        {
            get { return (duracao); }
            set { duracao = value; }
        }
        public double Custo
        {
            get { return (custo); }
            set { custo = value; }
        }
        public Cliente CallNumber
        {
            get { return (callNumber); }
            set { callNumber = value; }
        }

        //Property Novas!! 
        public DateTime DataInicioChamada
        {
            get { return dataIncioChamada; }
            set { DataInicioChamada = value; }
        }

        public DateTime DataFimChamada
        {
            get { return dataFimChamada; }
            set { dataFimChamada = value; }
        }
        //Pequena modeificacao aqui!!
        public Cliente RecNumber
        {
            get { return (recNumber); }
            set { recNumber = value; }
        }

        public PlanoChamadaIlimitado PlanoChamadaAssMensal
        {
            get { return genChamada; }
            set { genChamada = value; }
        }

        public EstadoChamada SituacaoChamada
        {
            get { return situacaoCorrenteCh; }
            set { situacaoCorrenteCh = value; }
        }

        #endregion

            #region Metodos

        
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

        public static bool apagarCham(Cliente p,int numChamada)
        {
            Cliente b = new Cliente(p.Nome, p.NumTel, p.Saldo);                                    
            int contador = 0;           
            foreach(Chamada x in p.Registo)
            {
                //Analisar aqui!

                /*
                if (p.Registo[numChamada].Duracao<1 || p.Registo[numChamada]!=null || p.Registo[numChamada].Mes<1)
                {
                    continue;
                }
                */
                if (contador == 0) contador = 1; // isto nao está bem modificar conforme 
                //o if acima
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
			DateTime date;
			bool resultado = DateTime.TryParse(Console.ReadLine(), out date);
            if (resultado == false)
            {
                //Console.WriteLine("Dados mal inseridos, por favor reinsira-os");
				return -1;
            }
			else if (date.Month < 1 && date.Month > 12)
            {
                //Console.WriteLine("Dados mal inseridos, por favor reinsira-os");
				resultado = DateTime.TryParse(Console.ReadLine(), out date);
                if (resultado == false)
                {
                    //Console.WriteLine("Dados mal inseridos, por favor reinsira-os");
					resultado = DateTime.TryParse(Console.ReadLine(), out date);
                }
            }
			return date.Month;
        }
        public static int getDia()
        {
			DateTime day; // Data inserida
			bool resultado = DateTime.TryParse(Console.ReadLine(), out day);
            if (resultado == false)
            {
				return -1;
                //resultado = int.TryParse(Console.ReadLine(), out dia);
            }
			else if (day.Day< 1 && day.Day > 31)
            {
                //Console.WriteLine("Dados mal inseridos, por favor reinsira-os");
				resultado = DateTime.TryParse(Console.ReadLine(), out day);
                if (resultado == false)
				{   
					return -1;
                    
					//Console.WriteLine("Dados mal inseridos, por favor reinsira-os");


					//resultado = DateTime.TryParse(Console.ReadLine(), out day);
                }
            }
			return day.Day;
        }
		public static TimeSpan contarDuracao(DateTime inicioCh, DateTime fimCh)
        {
           
			duration = inicioCh - fimCh;

			if (duration <= TimeSpan.FromTicks(0))
				return  TimeSpan.FromTicks(-1);
		   
            return duration;
        }
        /*
        public override string ToString()
        {
            return base.ToString() + "\tMES: " + Mes.ToString() + "\tDIA: " + Dia.ToString() + ":\nCaller info:\n\tNome: " + Callnumber.Nome.ToString() + "\tNumero: " + Callnumber.NumTel.ToString() + "\nReceiver info:\n\tNome: " + Recnumber.Nome.ToString() + "\tNumero: " + Recnumber.NumTel.ToString()+"\nCusto: "+Custo.ToString()+"Duracao: "+Duracao.ToString();
        }
        */
        
    }

        #endregion
    }
