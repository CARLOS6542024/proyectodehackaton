// Importa las librerías necesarias de ASP.NET Core y LINQ para la manipulación de colecciones
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace proyectodehackaton.Pages
{
    // CLASE MODELO 1: Define los atributos de cada producto en el catálogo
    public class Producto
    {
        public string Sku { get; set; }        // Código único de identificación
        public string Nombre { get; set; }     // Nombre comercial del producto
        public double Precio { get; set; }     // Precio en moneda local
        public string ImagenUrl { get; set; }  // Enlace a la imagen del producto
        public string Categoria { get; set; }  // Departamento: "Ropa", "Electronicos", "Calzado", "Alimentos"
    }

    // CLASE MODELO 2: Define los elementos agregados dentro del carrito de compras
    public class ItemCarrito
    {
        public string Sku { get; set; }        // SKU de referencia
        public string Nombre { get; set; }     // Nombre del artículo
        public double Precio { get; set; }     // Precio unitario
        public int Cantidad { get; set; }      // Cantidad acumulada
        public double Subtotal => Precio * Cantidad; // Cálculo automático del subtotal por producto
    }

    // CLASE PRINCIPAL DEL MODELO DE PÁGINA (PageModel)
    public class IndexModel : PageModel
    {
        // CATÁLOGO GENERAL ESTÁTICO: 4 Departamentos con 10 productos cada uno (40 en total)
        public static List<Producto> Catalogo { get; set; } = new List<Producto>
        {
            // ================= DEPARTAMENTO: ROPA (10 Productos) =================
            new Producto { Sku = "ROP-101", Nombre = "Sudadera Oversize", Precio = 650.00, Categoria = "Ropa", ImagenUrl = "https://http2.mlstatic.com/D_NQ_NP_724224-MLM115225909707_072026-O.webp" },
            new Producto { Sku = "ROP-102", Nombre = "Pantalón Mezclilla", Precio = 750.00, Categoria = "Ropa", ImagenUrl = "https://www.unitam.com/media/catalog/product/cache/8bf5895435943fcf2da0fe7d650ab2c4/p/a/paiscr0a2333c_1frente.jpg" },
            new Producto { Sku = "ROP-103", Nombre = "Playera Algodón", Precio = 700.00, Categoria = "Ropa", ImagenUrl = "https://kgprint.mx/wp-content/uploads/2024/12/PLAYERA-HO-CUELLO-REDONDO-NEGRA-scaled-1.jpg" },
            new Producto { Sku = "ROP-104", Nombre = "Chamarra Mezclilla", Precio = 900.00, Categoria = "Ropa", ImagenUrl = "https://m.media-amazon.com/images/I/517x-fe7x7L._AC_SY1000_.jpg" },
            new Producto { Sku = "ROP-105", Nombre = "Camisa Casual Larga", Precio = 500.00, Categoria = "Ropa", ImagenUrl = "https://sp223.liverpool.com.mx/i/1119271149.jpg" },
            new Producto { Sku = "ROP-106", Nombre = "Vestido Estampado", Precio = 750.00, Categoria = "Ropa", ImagenUrl = "https://lineas.com.mx/wp-content/uploads/2026/02/vestidotir2.jpg" },
            new Producto { Sku = "ROP-107", Nombre = "Shorts Deportivos", Precio = 350.00, Categoria = "Ropa", ImagenUrl = "https://detqhtv6m6lzl.cloudfront.net/HCLContenido/producto/FullImage/MK-7502281102198-1.jpg" },
            new Producto { Sku = "ROP-108", Nombre = "Saco Elegante", Precio = 1200.00, Categoria = "Ropa", ImagenUrl = "https://resources.sears.com.mx/medios-plazavip/fotos/productos_sears1/original/5043668.jpg" },
            new Producto { Sku = "ROP-109", Nombre = "Falda Plisada", Precio = 350.00, Categoria = "Ropa", ImagenUrl = "https://vertiche.mx/wp-content/uploads/2026/07/L18039-NEGRO-1.jpg" },
            new Producto { Sku = "ROP-110", Nombre = "Pijama Completa", Precio = 500.00, Categoria = "Ropa", ImagenUrl = "https://m.media-amazon.com/images/I/41eebBk23ML._AC_SY1000_.jpg" },

            // ================= DEPARTAMENTO: ELECTRÓNICOS (10 Productos) =================
            new Producto { Sku = "ELE-201", Nombre = "Audífonos Inalámbricos", Precio = 1500.00, Categoria = "Electronicos", ImagenUrl = "https://png.pngtree.com/png-vector/20241021/ourmid/pngtree-3d-compact-ear-pods-with-bluetooth-connectivity-on-transparent-background-png-image_14106614.png" },
            new Producto { Sku = "ELE-202", Nombre = "Reloj Inteligente", Precio = 2500.00, Categoria = "Electronicos", ImagenUrl = "https://png.pngtree.com/png-clipart/20250104/original/pngtree-smart-watch-png-image_18709852.png" },
            new Producto { Sku = "ELE-203", Nombre = "Bocina Bluetooth", Precio = 900.00, Categoria = "Electronicos", ImagenUrl = "https://png.pngtree.com/png-vector/20241208/ourlarge/pngtree-bluetooth-speaker-illustration-png-image_14700206.png" },
            new Producto { Sku = "ELE-204", Nombre = "Cámara Web Full HD", Precio = 550.00, Categoria = "Electronicos", ImagenUrl = "https://static.vecteezy.com/system/resources/previews/027/124/784/non_2x/webcam-gaming-3d-illustration-png.png" },
            new Producto { Sku = "ELE-205", Nombre = "Teclado Mecánico RGB", Precio = 1500.00, Categoria = "Electronicos", ImagenUrl = "https://png.pngtree.com/png-vector/20250321/ourmid/pngtree-a-isolated-wirless-mechanical-keyboard-on-white-background-png-image_15836493.png" },
            new Producto { Sku = "ELE-206", Nombre = "Mouse Gamer Ergonómico", Precio = 600.00, Categoria = "Electronicos", ImagenUrl = "https://ddtech.mx/assets/uploads/8ee140df6eb8b5c3b104dae5d1b54283.png" },
            new Producto { Sku = "ELE-207", Nombre = "Monitor 24 Pulgadas", Precio = 3200.00, Categoria = "Electronicos", ImagenUrl = "https://operadorabaam.com.mx/img/p/1/2/6/126-large_default.jpg" },
            new Producto { Sku = "ELE-208", Nombre = "Batería Portátil Powerbank", Precio = 600.00, Categoria = "Electronicos", ImagenUrl = "https://png.pngtree.com/png-vector/20250401/ourmid/pngtree-portable-power-bank-with-dual-usb-ports-fast-charging-technology-and-png-image_15921903.png" },
            new Producto { Sku = "ELE-209", Nombre = "Tablet Android 10\"", Precio = 4500.00, Categoria = "Electronicos", ImagenUrl = "https://png.pngtree.com/png-vector/20250609/ourmid/pngtree-exploring-the-features-and-benefits-of-using-samsung-tablets-for-android-png-image_15994321.png" },
            new Producto { Sku = "ELE-210", Nombre = "Micrófono Condensador USB", Precio = 950.00, Categoria = "Electronicos", ImagenUrl = "https://png.pngtree.com/png-vector/20240331/ourmid/pngtree-studio-condenser-microphone-on-transparent-background-png-image_12253527.png" },

            // ================= DEPARTAMENTO: CALZADO (10 Productos) =================
            new Producto { Sku = "CAL-301", Nombre = "Tenis Deportivos", Precio = 1500.00, Categoria = "Calzado", ImagenUrl = "https://png.pngtree.com/png-vector/20250119/ourmid/pngtree-sleek-black-sports-shoes-are-perfect-for-an-active-lifestyle-blending-png-image_15267342.png" },
            new Producto { Sku = "CAL-302", Nombre = "Botas de Piel", Precio = 2000.00, Categoria = "Calzado", ImagenUrl = "https://png.pngtree.com/png-vector/20250103/ourmid/pngtree-classic-brown-leather-cowboy-boots-with-intricate-design-png-image_15033545.png" },
            new Producto { Sku = "CAL-303", Nombre = "Sandalias Casuales", Precio = 450.00, Categoria = "Calzado", ImagenUrl = "https://static.vecteezy.com/system/resources/previews/066/666/366/non_2x/tan-leather-sandals-with-buckles-on-transparent-background-for-casual-footwear-display-png.png" },
            new Producto { Sku = "CAL-304", Nombre = "Zapatos de Vestir", Precio = 1300.00, Categoria = "Calzado", ImagenUrl = "https://png.pngtree.com/png-vector/20240729/ourmid/pngtree-men-formal-shoes-png-image_13287455.png" },
            new Producto { Sku = "CAL-305", Nombre = "Tenis Urbanos Canvas", Precio = 850.00, Categoria = "Calzado", ImagenUrl = "https://yage.tech/2026/06/7861067087358-1.png" },
            new Producto { Sku = "CAL-306", Nombre = "Mocasines de Cuero", Precio = 1100.00, Categoria = "Calzado", ImagenUrl = "https://png.pngtree.com/png-vector/20240824/ourmid/pngtree-3d-loafer-shoes-for-man-isolated-black-color-png-image_13603809.png" },
            new Producto { Sku = "CAL-307", Nombre = "Botines de Gamuza", Precio = 1600.00, Categoria = "Calzado", ImagenUrl = "https://w7.pngwing.com/pngs/263/543/png-transparent-riding-boot-suede-shoe-high-heeled-footwear-black-boots-black-hair-leather-boots.png" },
            new Producto { Sku = "CAL-308", Nombre = "Zapatillas de Tacón", Precio = 900.00, Categoria = "Calzado", ImagenUrl = "https://e7.pngegg.com/pngimages/417/953/png-clipart-shoe-high-heeled-footwear-illustration-women-shoes-outdoor-shoe-sneakers.png" },
            new Producto { Sku = "CAL-309", Nombre = "Pantuflas Térmicas", Precio = 400.00, Categoria = "Calzado", ImagenUrl = "https://colombia.com.co/wp-content/uploads/2025/09/Babuchas-pantuflas-termica-mujer-tipo-zapato-2.png.webp" },
            new Producto { Sku = "CAL-310", Nombre = "Tenis Running Pro", Precio = 1500.00, Categoria = "Calzado", ImagenUrl = "https://static.nike.com/a/images/t_web_pw_592_v2/f_auto/u_9ddf04c7-2a9a-4d76-add1-d15af8f0263d,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/ad6e7643-0fa2-4c98-939a-eefb43383573/W+NIKE+AIR+ZOOM+PEGASUS+42.png" },

            // ================= DEPARTAMENTO: ALIMENTOS (10 Productos Nuevos) =================
            new Producto { Sku = "ALI-401", Nombre = "Leche Entera 1L", Precio = 25.50, Categoria = "Alimentos", ImagenUrl = "https://lechesanmarcos.com/contenido-lsm/uploads/2025/06/Leche-UHT-Entera.png" },
            new Producto { Sku = "ALI-402", Nombre = "Pan Integral Artesanal", Precio = 35.00, Categoria = "Alimentos", ImagenUrl = "https://d2kzln7vi31e50.cloudfront.net/s3fs-public/Artesano%20IDEAL%20Integral%20600g%20oroweat%20511x643.png" },
            new Producto { Sku = "ALI-403", Nombre = "Huevo Blanco 12 pzs", Precio = 55.00, Categoria = "Alimentos", ImagenUrl = "https://cdn.alsuper.com/products/655.png" },
            new Producto { Sku = "ALI-404", Nombre = "Cereal Avena 500g", Precio = 50.50, Categoria = "Alimentos", ImagenUrl = "https://www.nestle-cereals.com/mx/sites/g/files/qirczx856/files/2022-09/Cheerios%20Avena%20integral_0.png" },
            new Producto { Sku = "ALI-405", Nombre = "Café Soluble 200g", Precio = 75.00, Categoria = "Alimentos", ImagenUrl = "https://res.cloudinary.com/riqra/image/upload/w_656,h_656,c_limit,q_auto,f_auto/v1787986039/merco-monterrey/products/6eab4b92fee29318.png" },
            new Producto { Sku = "ALI-406", Nombre = "Aceite de Oliva 500ml", Precio = 120.00, Categoria = "Alimentos", ImagenUrl = "https://thumbs.dreamstime.com/b/botella-de-aceite-oliva-png-con-fondo-transparente-381665721.jpg" },
            new Producto { Sku = "ALI-407", Nombre = "Arroz Súper Extra 1kg", Precio = 30.00, Categoria = "Alimentos", ImagenUrl = "https://subodega.mx/articulo/75/01.webp" },
            new Producto { Sku = "ALI-408", Nombre = "Frijol Negro 1kg", Precio = 30.50, Categoria = "Alimentos", ImagenUrl = "https://www.laranitadelapaz.com.mx/images/thumbs/0005559_frijol-negro-jamapa-verde-valle-bolsa-de-1-kg_625.jpeg" },
            new Producto { Sku = "ALI-409", Nombre = "Atún en Agua 140g", Precio = 20.00, Categoria = "Alimentos", ImagenUrl = "https://cugat.cl/wp-content/uploads/2024/10/cugat.cl-atun-otuna-agua-lomitos-140-gr.png" },
            new Producto { Sku = "ALI-410", Nombre = "Queso Manchego 400g", Precio = 75.00, Categoria = "Alimentos", ImagenUrl = "https://lyncott.mx/wp-content/uploads/2020/01/MANCHEGO_400-1.png" }
        };

        // LISTA ESTÁTICA DEL CARRITO: Conserva las compras sin importar el departamento navegada
        public static List<ItemCarrito> Carrito { get; set; } = new List<ItemCarrito>();

        // PROPIEDADES DE ESTADO PARA LA VISTA (HTML)
        public List<Producto> ProductosFiltrados { get; set; } = new List<Producto>(); // Productos visibles
        public string CategoriaSeleccionada { get; set; } = "Todas";                   // Categoría activa
        public bool AbrirCarrito { get; set; } = false;                                // Controla despliegue automático del panel lateral

        // CÁLCULOS DINÁMICOS CON LINQ
        public double TotalPagar => Carrito.Sum(item => item.Subtotal); // Sumatoria total
        public int CantidadTotal => Carrito.Sum(item => item.Cantidad); // Sumatoria de piezas

        // MÉTODO HTTP GET: Se ejecuta al cambiar de pestaña en la navegación superior
        public void OnGet(string categoria)
        {
            FiltrarProductos(categoria);
        }

        // MÉTODO HTTP POST: Se ejecuta al presionar "Añadir al Carrito" en cualquier producto
        public void OnPostAgregar(string sku, string categoria)
        {
            // Busca el producto en el catálogo general mediante SKU
            var producto = Catalogo.FirstOrDefault(p => p.Sku == sku);

            if (producto != null)
            {
                // Verifica si el artículo ya estaba dentro del carrito
                var itemExistente = Carrito.FirstOrDefault(i => i.Sku == sku);

                if (itemExistente != null)
                {
                    itemExistente.Cantidad++; // Incrementa las piezas existentes
                }
                else
                {
                    // Añade un nuevo elemento si es la primera vez que se agrega
                    Carrito.Add(new ItemCarrito
                    {
                        Sku = producto.Sku,
                        Nombre = producto.Nombre,
                        Precio = producto.Precio,
                        Cantidad = 1
                    });
                }
            }

            FiltrarProductos(categoria); // Mantiene el filtro del departamento actual
            AbrirCarrito = true;         // Activa la bandera para que se deslice el panel del carrito
        }

        // MÉTODO HTTP POST: Se ejecuta al presionar "Vaciar Carrito"
        public void OnPostLimpiar(string categoria)
        {
            Carrito.Clear();             // Limpia la lista estática del carrito
            FiltrarProductos(categoria); // Mantiene el contexto de categoría
            AbrirCarrito = true;         // Mantiene visible el menú desplegable mostrando que quedó en 0
        }

        // MÉTODO PRIVADO AUXILIAR: Filtra la lista según la categoría o las muestra todas
        private void FiltrarProductos(string categoria)
        {
            CategoriaSeleccionada = string.IsNullOrEmpty(categoria) ? "Todas" : categoria;

            if (CategoriaSeleccionada == "Todas")
            {
                ProductosFiltrados = Catalogo; // Muestra los 40 productos
            }
            else
            {
                // Filtra utilizando LINQ coincidiendo el nombre de la categoría
                ProductosFiltrados = Catalogo.Where(p => p.Categoria == CategoriaSeleccionada).ToList();
            }
        }
    }
}