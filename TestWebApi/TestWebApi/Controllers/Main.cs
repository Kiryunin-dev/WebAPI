using Microsoft.AspNetCore.Mvc;

namespace TestWebApi.Controllers
{
    /// <summary>
    /// Основной контроллер
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class Main : ControllerBase
    {
        /// <summary>
        /// Получение квадрата числа
        /// </summary>
        /// <response code="200">Успешное возвращение значения</response>
        /// <response code="500">Внутренняя ошибка сервиса</response>
        [HttpGet("GetSquare")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public long Square(long value1, long value2)
        {
            return value1 * value2;
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
