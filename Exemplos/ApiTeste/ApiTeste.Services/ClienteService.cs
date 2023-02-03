using ApiTeste.Domain.Exceptions;
using ApiTeste.Domain.Models;
using ApiTeste.Repositories.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApiTeste.Services
{
    public class ClienteService
    {
        private readonly ClienteRepositorio _repositorio;
        public ClienteService(ClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Cliente> Listar(string? nome)
        {
            return _repositorio.ListarClientes(nome);

        }
        public Cliente Obter(string cpfCliente)
        {
            return _repositorio.Obter(cpfCliente);
        }
        public void Atualizar(Cliente model)
        {

            ValidarModelCliente(model, true);

            if (!_repositorio.SeExiste(model.CpfCliente))
                throw new ValidacaoException("O usuário que você está tentando atualizar não existe.");

            var registroExistente = _repositorio.Obter(model.CpfCliente);

            model.Id = registroExistente.Id;

            _repositorio.Atualizar(model);

        }
        public void Deletar(string cpfCliente)
        {

            _repositorio.Deletar(cpfCliente);

        }
        public void Inserir(Cliente model)
        {

            ValidarModelCliente(model);
            model.Id = Guid.NewGuid().ToString();

            if (_repositorio.SeExiste(model.CpfCliente))
                throw new ValidacaoException("O usuário que você está tentando incluir já existe.");

            _repositorio.Inserir(model);

        }

        private static void ValidarModelCliente(Cliente model, bool isUpdate = false)
        {
            if (model is null)
                throw new ValidacaoException("O json está mal formatado, ou foi enviado vazio.");

            if (!isUpdate)
            {
                if (string.IsNullOrWhiteSpace(model.CpfCliente))
                    throw new ValidacaoException("O cpfCliente e obrigatório.");

                if (!ValidarCpf(model.CpfCliente))
                    throw new ValidacaoException("O cpfCliente e inválido.");
            }

            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new ValidacaoException("O nome e obrigatório.");

            if (model.Nome.Trim().Length < 3 || model.Nome.Trim().Length > 255)
                throw new ValidacaoException("O nome precisa ter entre 3 a 255 caracteres.");

            if (ObterIdade(model.Nascimento) < 18)
                throw new ValidacaoException("Somente maiores de 18 anos podem ser cadastrados como clientes.");

            if (model.Telefone is not null
                &&
                (model.Telefone.Trim().Length < 11
                || model.Telefone.Trim().Length > 15
                || model.Telefone.Trim().Length != RemoverMascaraTelefone(model.Telefone).Length)
                )
                throw new ValidacaoException("O mínimo que o telefone pode ter são 11 a 15 digitos, e não pode conter mascaras.");

            model.Nome = model.Nome.Trim();
            model.Telefone = model.Telefone?.Trim();
        }

        private static int ObterIdade(DateTime birthdate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthdate.Year;
            if (birthdate > today.AddYears(-age)) age--;
            return age;
        }
        private static string RemoverMascaraTelefone(string phoneNumber)
        {
            return Regex.Replace(phoneNumber, @"[^\d]", "");
        }
        private static bool ValidarCpf(string? cpf)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cpf))
                    return false;

                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;
                cpf = cpf.Trim();
                cpf = cpf.Replace(".", "").Replace("-", "");
                if (cpf.Length != 11)
                    return false;
                tempCpf = cpf.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return cpf.EndsWith(digito);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
