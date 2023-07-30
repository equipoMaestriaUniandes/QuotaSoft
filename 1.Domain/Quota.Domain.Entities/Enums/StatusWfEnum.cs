namespace Quota.Domain.Entities.Enums
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public struct StatusWfEnum
    {
        public const string
            pendiente = "1. PENDIENTE",
            enProceso = "2. EN PROCESO",
            reenviado = "3. REENVIADO",
            compartido = "4. COMPARTIDO",
            finalizado = "5. FINALIZADO",
            reenviarTodos = "6. REENVIAR A TODOS",
            aprobadoReenviado = "7. APROBADO Y REENVIAR",
            rechazoReenviar = "8. RECHAZADO Y REENVIAR";
    }
}
