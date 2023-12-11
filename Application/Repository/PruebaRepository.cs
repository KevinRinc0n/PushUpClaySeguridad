// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace Application.Repository
// {
//     public class PruebaRepository
//     {
//         public async Task<IEnumerable<Cliente>> clientesSinPagos2()
//     {
//         var clientesConPagos = await _context.Pagos
//             .Select(p => p.CodigoCliente)
//             .Distinct()
//             .ToListAsync();

//         var clientesSinPagos = await _context.Clientes
//             .Where(c => !clientesConPagos.Contains(c.CodigoCliente))
//             .ToListAsync();

//         return clientesSinPagos;
//     }

//     public async Task<IEnumerable<Cliente>> clientcConPagos()
//     {
//         var clientesConPagos = await _context.Clientes
//             .Where(c => _context.Pagos.Any(p => p.CodigoCliente == c.CodigoCliente))
//             .ToListAsync();

//         return clientesConPagos;
//     }

//     public async Task<IEnumerable<object>> pedidosClient()
//     {
//         var clientesConPedidos = await _context.Clientes
//             .Select(c => new
//             {
//                 NombreCliente = c.NombreCliente,
//                 CantidadPedidos = c.Pedidos.Count
//             })
//             .ToListAsync();

//         return clientesConPedidos;
//     }

//     public async Task<IEnumerable<string>> pedidosClientes2008()
//     {
//         var clientesConPedidos2008 = await _context.Clientes
//             .Where(cliente => cliente.Pedidos.Any(pedido => pedido.FechaPedido.Year == 2008))
//             .OrderBy(cliente => cliente.NombreCliente)
//             .Select(cliente => cliente.NombreCliente)
//             .ToListAsync();

//         return clientesConPedidos2008;
//     }

//     public async Task<IEnumerable<object>> clientesNoPago()
//     {
//         var clientesSinPagos = await _context.Clientes
//             .Where(cliente => cliente.Pagos == null || cliente.Pagos.Count == 0)
//             .Select(cliente => new
//             {
//                 NombreCliente = cliente.NombreCliente,
//                 NombreRepresentanteVentas = $"{cliente.CodigoEmpleadoRepVentasNavigation.Nombre} {cliente.CodigoEmpleadoRepVentasNavigation.Apellido1}",
//                 TelefonoOficinaRepresentanteVentas = cliente.CodigoEmpleadoRepVentasNavigation.CodigoOficinaNavigation.Telefono
//             })
//             .ToListAsync();

//         return clientesSinPagos;
//     }
//     }
// }