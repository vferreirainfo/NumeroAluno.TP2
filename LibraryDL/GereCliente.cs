using LibraryBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDL
{
    
    class GereCliente
    {
        bool methodReturn; // para manipular o que cada metodo com tipo de dados "bool" ira retomar
        bool existeCliente;
        const int MAXCLIENTES = 5000;

        Cliente[] conjuntoClientes = new Cliente[MAXCLIENTES];


        public GereCliente()
        {

        }
        public GereCliente (Cliente [] arrayClientes)
        {
            conjuntoClientes = arrayClientes;
        }




        #region property
        public Cliente [] GestaoConjuntoClientes
        {
            get { return conjuntoClientes; }
            set { conjuntoClientes = value; }
        }


        #endregion



        #region metodos
        public bool criarVariosClientes(Cliente [] conjClientes)
        {
            for (int i=0; i<conjuntoClientes.Length; i++)
            {
                for(int j=0; j<conjClientes.Length; j++)
                {
                    // se ha posicao vazia no array conjuntoClientes
                    // e se conjClientes[j] != null (contem dados)
                    if (conjuntoClientes[i] == null && conjClientes[j] != null)
                    {
                        // Se nao existe o cliente no array conjuntoClientes[i]
                        if(conjuntoClientes[i]!=conjuntoClientes[j])
                        { 
                            conjuntoClientes[i] = conjClientes[j];
                            methodReturn = true;
                        }
                    }
                    else
                        methodReturn = false;
                }
            }
            return methodReturn;
        }

        public bool verificaAdicionaCliente (Cliente customer)
        {
          
            // iteração com o array de clientes
            for (int i=0; i<conjuntoClientes.Length; i++)
            {
                //verificar se existe
                if (conjuntoClientes[i] == customer)
                { 
                    methodReturn = false;
                    break;
                }
                else if(conjuntoClientes[i]==null && conjuntoClientes[i] != customer)
                {
                    conjuntoClientes[i] = customer;
                    methodReturn = true;
                    break;
                }  
          }
            return methodReturn;
        }

        public bool removerCliente(Cliente customer)
        {
            //procurar o mesmo no array
            for (int i=0; i<conjuntoClientes.Length; i++)
            {
                // Se existe o cliente
                if (conjuntoClientes[i] == customer)
                {
                    //marcar como eliminado para nao aparecer em consultas
                    conjuntoClientes[i].SituacaoCliente = EstadoCliente.Eliminado;
                    methodReturn = true;
                }
                else
                    methodReturn = false;
            }
            return methodReturn;
        }

        public bool removerDefinitivamenteCliente(Cliente customer)
        {
            Cliente nullable = null;
            //procurar o mesmo no array
            for (int i = 0; i < conjuntoClientes.Length; i++)
            {
                // Se existe o cliente
                if (conjuntoClientes[i] == customer)
                {
                    //marcar como eliminado para nao aparecer em consultas
                    conjuntoClientes[i] = nullable;
                    methodReturn = true;
                }
                else
                    methodReturn = false;
            }
        
            //mover se existir os clientes que estao a seguir aos eliminados
            //ex: remover 3 do array_original: 1 2 '3' 4 5 6;
            //mover no array 4 5 6: 1 2 3 4 5;

            for (int i=0; i<conjuntoClientes.Length; i++)
            {
                if(conjuntoClientes[i]==null)
                {
                    conjuntoClientes[i] = conjuntoClientes[i + 1];
                    conjuntoClientes[i + 1] = null;
                }
            }
            return methodReturn;
        }

        public Cliente adicionarSaldo (Cliente c, double saldo, out bool estado)
        {
            bool processo;
            if (saldo < 0 || saldo > 100)
                processo = false; // Parar por aqui: saldo inferior a 0 ou maior 
            //do que permitido  
            else
            {
                c.Saldo = saldo;
                processo = true;
            }
            estado = processo;
            return c;
        }
        


        public Cliente pagarMensalidade(Cliente c, double montanteRecebido, out double troco, out bool estado)
        {
            double mensalidade = 19.99;
            double dinheiroDev = 0;
            if (montanteRecebido < mensalidade)
                methodReturn = false; // se existir dineheiro em falta retomo
            // falso
            else
            {

                if (montanteRecebido == mensalidade)
                {
                    c.Saldo = montanteRecebido;
                    c.ChamadaFixo = 4000;
                    c.ChamadaMovel = 3000; // renovar servicos
                    methodReturn = true;
                }
                else if (montanteRecebido > mensalidade)
                {
                    dinheiroDev = montanteRecebido - mensalidade;
                    c.Saldo = mensalidade;
                    c.ChamadaFixo = 4000;
                    c.ChamadaMovel = 3000;// renovar servicos
                    methodReturn = true;
                }

            }
            troco = dinheiroDev;
            estado = methodReturn;
            return c;
        }

        public Cliente procurarConsultarCliente (Cliente c, out bool estado)
        {
            Cliente pessoa = null;
            // percorrer array conjuntoClientes
            for (int i=0; i<conjuntoClientes.Length; i++)
            {
                if (c == conjuntoClientes[i])
                {
                    //cliente encontrado
                    pessoa = conjuntoClientes[i]; //encontramos
                    methodReturn = true;
                }
                else
                    methodReturn = false;
            }
            estado = methodReturn;
            return pessoa;
        }


        public bool pagarMes(Cliente p, int numeroTel, int opcaoInserida,double montante)
        {
            Cliente clienteAtualizado;
            bool estado;
            numeroTel = int.Parse(p.NumTel.Substring(1, 1));
            switch (numeroTel)
            {
                case 1:
                    
                    if (p.Despesa > 0)
                    {

                        if (opcaoInserida == 1)
                        {
                            clienteAtualizado = adicionarSaldo(p, montante, out estado);
                            if (estado == true)
                            {
                                //fazer update no array
                                for (int i = 0; i < conjuntoClientes.Length; i++)
                                {
                                    if (conjuntoClientes[i] == p)
                                        conjuntoClientes[i] = clienteAtualizado;

                                }
                                methodReturn = true;

                            }
                            else if (estado == false)
                                methodReturn = false;
                        }
                       
                    }
                    else
                        methodReturn = false;
                    break;



                case 3:
                    
                    double troco=0; // se existir
                    int escolha1 = opcaoInserida;
                    if (p.Despesa > 0)
                    {
                        
                        if (escolha1 == 1)
                        {
                            //adicionarSaldo(p);
                             clienteAtualizado = pagarMensalidade(p,montante,out troco,out estado);
                             
                             if(estado==true)
                             {
                                   // ATUALIZAR NO ARRAY
                                   for (int i=0; i<conjuntoClientes.Length; i++)
                                    {
                                        if (conjuntoClientes[i] == p)
                                            conjuntoClientes[i] = clienteAtualizado;
                                    }
                             }
                        }
                        else { break; }
                    }
                    else
                    {
                        Console.WriteLine("Nao tem divida");
                    }
                    break;
                case 6:
                    //pagarMensalidade(p);
                    break;
                default: break;
            }
            return true;
        }

        #endregion
    }
}
