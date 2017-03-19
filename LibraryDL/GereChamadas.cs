using LibraryBO;
using System;

namespace LibraryDL
{
    public class GereChamadas
    {

        //Right there 
        const int CHAMADAFIXAPLILIMITADO = 3000;
        const int CHAMADAMOVELPLILIMITADO = 4000;
        const int CHAMADAS = 500000; //Para todosos outroe clientes
        static bool methodReturn; // variavel que guarda o que cada metodo estatico com tipo de dados bool irá retomar

        
        static int countChamadasFixIlimitado = 0, countChamadasMovIlimitado = 0; // contadores para os numeros cujo segundo digito é 10

        static Chamada[] chamadasSistIlimitado = new Chamada[CHAMADAFIXAPLILIMITADO+CHAMADAMOVELPLILIMITADO]; // array para todas as chamadas efetuadas por 1 cliente
        //que pertenca ao sistema ilimitado
        static Chamada[] chamadasCliente = new Chamada[CHAMADAS];
        

        //Um array para copiar chamadas existentes nos originais e retomar lá para cima as chamadas de determinado cliente
        static Chamada[] devolveTodasAsChamadas = new Chamada[CHAMADAS + CHAMADAFIXAPLILIMITADO + CHAMADAMOVELPLILIMITADO];
        

        public GereChamadas(){}

        public GereChamadas(Chamada [] ch, Chamada []chamadaSistIl)
        {
            chamadasCliente = ch;
            chamadasSistIlimitado = chamadaSistIl;
        }

        public GereChamadas(Chamada[] ch)
        {
            chamadasCliente = ch;
           
        }



        #region Property
        public Chamada [] ArrayChamadas
        {
            get { return chamadasCliente; }
            set { chamadasCliente = value; }
        }
        public Chamada[] ChamadaIlimitada
        {
            get { return chamadasSistIlimitado; }
            set { chamadasSistIlimitado = value; }
        }
        #endregion


        #region Metodos
        /// <summary>
        /// Mostra chamadas de todos os clientes da telecomunica
        /// </summary>
        /// <returns></returns>
        public static bool mostrarChamadas(out Chamada [] devolveChamada)
        {
            for (int i = 0; i < chamadasCliente.Length; i++)
            {
                for (int j = 0; j < chamadasSistIlimitado.Length; j++)
                {

                    // verificar se existe algum array nulo
                    if (chamadasCliente == null || chamadasSistIlimitado == null)
                    {
                        if (chamadasCliente == null) // o array chamadas cliente é nulo
                        {

                          //Como realizaria o mesmo sem 2 ciclos for ??

                          for(int k=0; k<chamadasSistIlimitado.Length; k++)
                          {
                                   for(int m=0; m<devolveTodasAsChamadas.Length; m++)
                                    {
                                        if(devolveTodasAsChamadas[m]==null)
                                            devolveTodasAsChamadas[m] = chamadasSistIlimitado[k];

                                        // Será que isto está completo !!
                                    }
                          }
                            //imprimir chamasSistIlimitado
                        }
                        else
                        {

                            //imprimir chamadasCliente

                            for (int k = 0; k < chamadasCliente.Length; k++)
                            {
                                for (int m = 0; m < devolveTodasAsChamadas.Length; m++)
                                {
                                    if (devolveTodasAsChamadas[m] == null)
                                        devolveTodasAsChamadas[m] = chamadasCliente[k];

                                    // Será que isto está completo !!
                                }
                            }
                        }
                    }
                    else if (chamadasCliente == null && chamadasSistIlimitado == null)
                        methodReturn = false;
                    

                }
            }
            devolveChamada = devolveTodasAsChamadas;
            return methodReturn;
        }   


        public static bool processaChamada(Chamada c) // 224 linhas de codigo
        {
                

            #region Telemovel
            
            
            if (c.CallNumber.NumTel.Substring(0, 1) == "9")
            {
                #region Telemovel-91

                if (c.CallNumber.NumTel.Substring(1, 1) == "1")
                {
                    if (c.RecNumber.NumTel.Substring(0, 1) == "9")
                    {

                        if (c.CallNumber.Saldo >= 0.05) // Processo a chamada
                        {
                            c.DataInicioChamada = DateTime.Now; // começa a chamada

                            for (int forOne = 0; forOne <= chamadasCliente.Length; forOne++) // A chamada vai ficar guardada num array de chamadas
                            {
                                // preciso de encontrar uma posicao vazia no array
                                if (chamadasCliente[forOne] == null)
                                {
                                    //Processar custo da chamada
                                    c.Custo = 0.05; // indica que custo passa a ser 0.05

                                    if (c.DataInicioChamada != null) // se terminar chamada
                                    {
                                        c.Duracao = Chamada.contarDuracao(c.DataInicioChamada, c.DataFimChamada);
                                        c.CallNumber.Saldo = c.CallNumber.Saldo - chamadasCliente[forOne].Custo;

                                        // adicionar chamada
                                        chamadasCliente[forOne] = c;
                                        methodReturn = true;
                                    }

                                }
                                else if (chamadasCliente[forOne] != null && forOne == chamadasCliente.Length) // se se verificar isto entao 
                                                                                                              // o array está todo ocupado
                                    methodReturn = false;
                         }
                        }
                        else // se nao existir saldo suficiente
                            methodReturn = false;//Nova instrucao
                    }
                    else if (c.RecNumber.NumTel.Substring(0, 1) == "2") // Quem atende tem numero fixo ... Que começa por 2 ?
                    {
                        if (c.CallNumber.Saldo >= 0.15) // Quem faz a chamada tem saldo igual superior a 0.15
                        {
                            c.DataInicioChamada = DateTime.Now; //Nova instrucao

                            for (int forTwo=0; forTwo<=chamadasCliente.Length; forTwo++)
                            {
                                // preciso de encontrar uma posicao vazia no array
                                if (chamadasCliente[forTwo] == null)
                                { 

                                    c.Despesa = 0.15;

                                    if (c.DataFimChamada != null) // se terminar chamada
                                    {
                                        // contar e guardar a duracao da chamada na respetiva variavel
                                        c.Duracao = Chamada.contarDuracao(c.DataInicioChamada, c.DataInicioChamada);
                                        // descontar ao saldo
                                        c.Saldo = c.Saldo - c.Despesa; 
                                        chamadasCliente[forTwo] = c; //adiciona chamada ao array
                                        methodReturn = true;
                                    }
                                }
                            }
                        }
                        else
                            methodReturn = false;

                    }
                }
                #endregion

                #region Telemovel-93

                else if (c.CallNumber.NumTel.Substring(1, 1) == "3")
                {
                    if (c.CallNumber.NumTel.Substring(0, 1) == "9")
                    {

                        for (int forThree = 0; forThree <= chamadasCliente.Length; forThree++)
                        {
                            //mes = mesc;
                            //dia = diac;
                            c.Custo = 0.80; 
                            if (c.DataFimChamada != null) // se terminar chamada
                            {
                                c.Duracao = Chamada.contarDuracao(c.DataInicioChamada, c.DataFimChamada);
                                c.CallNumber.Despesa = c.CallNumber.Despesa - (-c.Custo);

                            }
                        }

                    }
                    else if (c.RecNumber.NumTel.Substring(0, 1) == "2")
                    {

                        for (int forSix=0; forSix<chamadasCliente.Length; forSix++)
                        {
                            c.Custo = 0.17;
                            if (c.DataFimChamada != null) // se terminar chamada
                                {
                                    c.Duracao = Chamada.contarDuracao(c.DataInicioChamada, c.DataFimChamada);
                                    c.CallNumber.Saldo = c.CallNumber.Saldo + chamadasCliente[forSix].Custo;

                                }
                        }
                    }
                }

                #endregion

                #region Telemovel-96

                else if (c.CallNumber.NumTel.Substring(1, 1) == "6")
                {
                    if (c.RecNumber.NumTel.Substring(0, 1) == "9" || c.RecNumber.NumTel.Substring(0, 1) == "2")
                    {

                        for (int forFour = 0; forFour <= chamadasSistIlimitado.Length; forFour++)
                        {
                            while (chamadasSistIlimitado[forFour]==null) // percorrer o array a procura de eventuais chamadas deste cliente
                            {

                                if (chamadasSistIlimitado[forFour].PlanoChamadaAssMensal == PlanoChamadaIlimitado.chamadaFixa && countChamadasFixIlimitado <= CHAMADAFIXAPLILIMITADO)
                                    // vou incrementar com um dos contadores acima definidos
                                    countChamadasFixIlimitado++;
                                else if (chamadasSistIlimitado[forFour].PlanoChamadaAssMensal == PlanoChamadaIlimitado.chamadaMovel && countChamadasMovIlimitado <= CHAMADAMOVELPLILIMITADO)
                                    countChamadasMovIlimitado++;

                            }
                            //Processar e adiconar a chamada

                            for (int forFive=0; forFive<= chamadasSistIlimitado.Length; forFive++)
                            {
                                if(chamadasSistIlimitado[forFive]==null)
                                {
                                    //verificar limites de chamada (quantas chamadas restam para fixo e movel)
                                    if(countChamadasFixIlimitado < CHAMADAFIXAPLILIMITADO || countChamadasMovIlimitado < CHAMADAMOVELPLILIMITADO)
                                    {
                                        //contar duracao
                                        //se terminou chamada
                                        if(c.DataFimChamada != null)
                                        { 
                                            c.Duracao = Chamada.contarDuracao(c.DataInicioChamada, c.DataFimChamada);

                                            //Adicionar chamada ao array
                                            chamadasSistIlimitado[forFive] = c;
                                            methodReturn = true;
                                        }
                                    }
                                    else
                                    {
                                        methodReturn = false;
                                        break;
                                    }
                                }
                            }
                            // verificar se existe alguma posicao vazia ... caso nao exista? Teremos de contar
                            //caller.ChamadaMovel = caller.ChamadaMovel - 1;  
                        }
                        //mes = mesc;
                        //dia = diac;
                        // duracao = contarDuracao(caller, receiver);
                        
                    }
                    
                }
                #endregion

            }
            #endregion

            #region Telefone

            else if (c.CallNumber.NumTel.Substring(0, 1) == "2")//Se realiza de chamada de telefone fixo
            {
                if (c.RecNumber.NumTel.Substring(0, 1) == "9")//Se rececao de chamada de telemovel
                {


                    for (int forSeven=0; forSeven<chamadasCliente.Length; forSeven++)
                    { 
                        //O que falta??


                        //mes = mesc;
                        //dia = diac;
                        chamadasCliente[forSeven].Custo = 0.1;
                        chamadasCliente[forSeven].Duracao = Chamada.contarDuracao(c.DataInicioChamada, c.DataFimChamada);
                        chamadasCliente[forSeven].CallNumber.DespesaMes = chamadasCliente[forSeven].CallNumber.DespesaMes + 0.1;

                        //Adcionar ao array
                        chamadasCliente[forSeven] = c;
                    }
                }
                else if (c.RecNumber.NumTel.Substring(0, 1) == "2")//Se rececao de chamada de telefone fixo
                {
                    // Será que o for está bem declarado?? Nao irá estourar?
                    for(int forEight=0; forEight<=chamadasCliente.Length;forEight++)
                    {
                        // O que falta??

                        chamadasCliente[forEight].Custo =  0; //isto nao fazia falta!!
                        chamadasCliente[forEight] = c;
                        methodReturn = true;
                        
                    }
                    //mes = mesc;
                    //dia = diac;
                    
                    //duracao = contarDuracao(caller, receiver);
                }
            }
            #endregion
 
            return methodReturn;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        public static bool apagarCham(Cliente p,Chamada ch) // Porque deverei tirar "Cliente p" ??
        {

            //Assumindo que ch vem com dados e que sabemos o tipo de chamada
            //Cliente b = new Cliente(p.Nome, p.NumTel, p.Saldo);
            //int contador = 0;


            if (ch.PlanoChamadaAssMensal == PlanoChamadaIlimitado.chamadaFixa || ch.PlanoChamadaAssMensal == PlanoChamadaIlimitado.chamadaMovel)
            {
                foreach (Chamada x in chamadasSistIlimitado)
                {
                    if (x == ch)
                        x.SituacaoChamada = EstadoChamada.Eliminada;
                    
                }
                methodReturn = true;
            }
            else if(ch.PlanoChamadaAssMensal != PlanoChamadaIlimitado.chamadaFixa && ch.PlanoChamadaAssMensal != PlanoChamadaIlimitado.chamadaMovel)
            {
                foreach (Chamada y in chamadasCliente )
                {
                    if (y == ch)
                        y.SituacaoChamada = EstadoChamada.Eliminada;
                        
                }
                methodReturn = true;
            }
            else
                methodReturn = false;

            return methodReturn;
        }
        #endregion

    }
}
