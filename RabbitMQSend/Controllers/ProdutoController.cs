using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase {

    private readonly RabbitMqSender _rabbitMqSender;

    public ProdutoController(RabbitMqSender rabbitMqSender) {
        _rabbitMqSender = rabbitMqSender;
    }

    [HttpPost]
    public ActionResult<Produto> Post([FromBody] Produto produto) {
        _rabbitMqSender.SendProduct(produto);
        return produto == null ? NotFound() : Ok(produto);
    }

}