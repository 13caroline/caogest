using Microsoft.Win32;
using System;
using System.Collections.Generic;


namespace trial2.Models
{
	public class EncriptarPopulacao
	{

		List<Utilizador> utilizadores;
		List<Canil> canis;
		List<User> users;

		public EncriptarPopulacao()
		{
			utilizadores = new List<Utilizador>();
			canis = new List<Canil>();
			users = new List<User>();
		}

		public void EncriptarUtilizadores()
		{
			foreach (Utilizador u in utilizadores)
			{
				if (u.encriptado == 0)
				{
					u.encriptado = 1;
					u.localidade = Encriptar.Decrypt(u.localidade, "123abc");
					u.rua = Encriptar.Decrypt(u.rua, "1a2b3c");
					u.distrito = Encriptar.Decrypt(u.distrito, "cba321");
					u.cc = Encriptar.Decrypt(u.cc, "b32a1c");
					u.nome = Encriptar.Decrypt(u.nome, "1c2b3a");
				}
			}
		}

		public void EncriptarCanis()
		{
			foreach (Canil c in canis)
			{
				if (c.encriptado == 0)
				{
					c.encriptado = 1;
					c.localidade = Encriptar.Decrypt(c.localidade, "123abc");
					c.rua = Encriptar.Decrypt(c.rua, "1a2b3c");
					c.distrito = Encriptar.Decrypt(c.distrito, "cba321");
					c.nib = Encriptar.Decrypt(c.nib, "b32a1c");
					c.nome = Encriptar.Decrypt(c.nome, "bac321");
					c.contacto = Encriptar.Decrypt(c.contacto, "1c2b3a");
				}
			}
		}

		public void EncriptarUsers()
		{
			foreach (User us in users)
			{
				if (us.encriptado == 0)
				{
					us.encriptado = 1;
					us.password = Encriptar.Encrypt(us.password, "abc123");
				}
			}
		}

		public void EncriptarPopul()
        {
			// Load das tabelas Utilizadores Users e Canis da Base de Dados para as Listas

			EncriptarUtilizadores();
			EncriptarCanis();
			EncriptarUsers();

			// Escrever o conteudo das Listas como Sendo as novas tabelas da Base de Dados
        }

	}
}
