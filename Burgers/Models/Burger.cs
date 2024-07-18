using System.Text.Json.Serialization;

namespace BurgerApi.Burgers.Models;

public class Burger {
    public Guid Id { get; init; }
    public string Nome { get; private set; }
    public bool Ativo { get; private set; }
    public Guid? ComboId { get; private set; }
    
    [JsonIgnore]
    public Combo Combo { get; private set; }


    public Burger(string nome) {
        Nome = nome;
        Id = Guid.NewGuid();
        Ativo = true;
    }

    public void atualizarNome(string nome) {
        Nome = nome;
    }

    public void desativar () {
        Ativo = false;
    }
}