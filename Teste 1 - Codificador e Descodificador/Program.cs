﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Teste_1___Codificador_e_Descodificador
{
    class Codificacao
    {
        #region Atributos
        public string frase;
        private char[,] matrizFrase;
        #endregion

        #region Construtor
        public Codificacao(string frase)
        {
            this.frase = frase;
            matrizFrase = new char[frase.Length, frase.Length];
        }
        #endregion
    }
    class Decodificacao
    {
        #region Atributos
        private string fraseCriptografada;
        private int indiceFrase;
        private char[,] matrizFrase;
        #endregion

        #region Construtores
        public Decodificacao(string fraseCompleta)
        {
            //Regex usado para separar os dados frase e indice
            Regex retirandoInformacoes = new Regex(@"\[\'(.*)\',\s?(\d+)\]");
            Match encontrados = retirandoInformacoes.Match(fraseCompleta);

            fraseCriptografada = encontrados.Groups[1].Value;
            indiceFrase = Convert.ToInt32(encontrados.Groups[2].Value);
            matrizFrase = new char[fraseCriptografada.Length, fraseCriptografada.Length];
        }
        #endregion

        #region métodos
        public string retornaRespostaDescodificada()
        {
            for (int colunas = fraseCriptografada.Length - 1; colunas > -1; colunas--)
            {
                //Add
                for (int linha = 0; linha < fraseCriptografada.Length; linha++)
                    matrizFrase[linha, colunas] = fraseCriptografada[linha];

                //Sort
            }

            //Recolhendo a linha com a palavra correta
            char[] palavraCorreta = new char[fraseCriptografada.Length];
            for (int pos = 0; pos < fraseCriptografada.Length; pos++)
            {
                palavraCorreta[pos] = matrizFrase[indiceFrase, pos];
            }

            return new string(palavraCorreta);
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
