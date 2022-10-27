using Microsoft.AspNetCore.Mvc;

namespace TestWebApi.Controllers
{
    /// <summary>
    /// Основной контроллер
    /// </summary>
    //[ApiController]
    //[ApiVersion("5.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class Main_two : ControllerBase
    {
        /// <summary>
        /// Получение квадрата числа
        /// </summary>
        /// <response code="200">Успешное возвращение значения</response>
        /// <response code="500">Внутренняя ошибка сервиса</response>
        [HttpGet("GetQuadro")]
        [MapToApiVersion("5.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string Quadro()
        {
            return "Quadro";
        }

        /// <summary>
        /// Получение квадрата числа
        /// </summary>
        /// <response code="200">Успешное возвращение значения</response>
        /// <response code="500">Внутренняя ошибка сервиса</response>
        [HttpGet("GetSquare3")]
        [MapToApiVersion("3.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string Square3()
        {
            return "Square3";
        }

        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <response code="200">Успешное удаление элемента</response>
        /// <response code="400">Ошибка при удалении элемента</response>
        /// <response code="500">Собственная ошибка веб службы</response>
        [HttpDelete("DeleteItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public long Error()
        {
            throw new TimeoutException();
        }

    }
}
