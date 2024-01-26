using CadastrosApi.Data;

namespace CadastrosApi.Models
{
    public static class UsuariosEndPoints
    {
        public static void AddEndPoints(this WebApplication app)
        {
            //Get
            app.MapGet(pattern:"cadastro", handler:(AppDbContext context) => {
                var usuarios = context.Usuarios;
                return usuarios;
            });

            //Post
            app.MapPost(pattern:"cadastro", handler:async (AddUsuarioRequest request, AppDbContext context) => {
                var NovoUsuario = new Usuario(request.Nome, request.Email, request.Senha);

                await context.Usuarios.AddAsync(NovoUsuario);
                await context.SaveChangesAsync();
            });

            //Put
            app.MapPut(pattern:"{id}", handler:async (Guid id, UpdateUsuario request, AppDbContext context) =>{
                var usuario = await context.Usuarios.FindAsync(id);

                if(usuario == null)
                    return Results.NotFound();

                usuario.AtualizarDados(request.Nome, request.Email, request.Senha);

                await context.SaveChangesAsync();
                return Results.Ok(usuario);
            });

            //Delete
            app.MapDelete(pattern:"{id}", handler:async (Guid id, AppDbContext context) => {
                if(await context.Usuarios.FindAsync(id) is Usuario usuario)
                {
                    context.Usuarios.Remove(usuario);
                    await context.SaveChangesAsync();
                    return Results.NoContent();
                }

                return Results.NotFound();
                
            });
        }
    }
}