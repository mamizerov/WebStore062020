﻿namespace WebStore062020.ViewModels
{
    public class CartOrderViewModel
    {
        public CartViewModel Cart { get; set; }

        public OrderViewModel Order { get; set; } = new OrderViewModel();
    }
}