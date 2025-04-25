﻿using Marketplace.Domain.Entities;
using System.Text.Json.Serialization;

public class DetallePedido
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }

    public int ProductoId { get; set; }
    public Producto Producto { get; set; }

    public int PedidoId { get; set; }
    [JsonIgnore]
    public Pedido? Pedido { get; set; }


}
