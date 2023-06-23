﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Filme
{

    //Atributos com validacoes
    [Required(ErrorMessage = "O título do filme é obrigatório")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O tamanho do gênero nao pode exceder 50 caracteres")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "O título do filme é obrigatório")]
    [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 a 600 minutos")]
    public int Duracao { get; set; }


}
