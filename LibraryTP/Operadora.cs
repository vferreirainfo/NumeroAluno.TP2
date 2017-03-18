using System;

namespace LibraryBO
{
	public class Operadora
	{

		const int MAXCLIENTES = 50000;
		Cliente[] arrayClientes = new Cliente[MAXCLIENTES];
		int indicativo;
		string nomeOperadora;


		public Operadora ()
		{
		}
		public Operadora(string nome, int indicOp)
		{
			nomeOperadora = nome;
			indicativo = indicOp;
		}


		public Cliente [] GereClientes
		{
			get{ return arrayClientes; }
			set{ arrayClientes = value; }
		}

		public int IndicativoTelefone {
			get{ return indicativo; }
			set{ indicativo = value; }
		}
			
		public string NomeOperadora {
			get{ return nomeOperadora; }
			set{ nomeOperadora = value; }
		}
	}
}

