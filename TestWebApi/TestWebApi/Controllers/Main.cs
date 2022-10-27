using Microsoft.AspNetCore.Mvc;

namespace TestWebApi.Controllers
{
    /// <summary>
    /// Основной контроллер
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("4.5")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class Main : ControllerBase
    {
        /// <summary>
        /// Получение квадрата числа
        /// </summary>
        /// <response code="200">Успешное возвращение значения</response>
        /// <response code="500">Внутренняя ошибка сервиса</response>
        [HttpGet("GetSquare")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string Square()
        {
            return "Square1";
        }

        /// <summary>
        /// Получение квадрата числа
        /// </summary>
        /// <response code="200">Успешное возвращение значения</response>
        /// <response code="500">Внутренняя ошибка сервиса</response>
        [HttpGet("GetSquare")]
        [MapToApiVersion("4.5")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string Square4()
        {
            return "Square4.5";
        }

        ///// <summary>
        ///// Получение квадрата числа
        ///// </summary>
        ///// <response code="200">Успешное возвращение значения</response>
        ///// <response code="500">Внутренняя ошибка сервиса</response>
        //[HttpGet("GetSquare")]
        //[MapToApiVersion("2.0")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public string Square2()
        //{
        //    return "Square2";
        //}

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
