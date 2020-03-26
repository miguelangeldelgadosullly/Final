<template>
<div>
    <h2>{{  pageTitle }}</h2>
    <el-form v-loading="loading" :model="form" :rules="rules" ref="ruleForm">

      <el-form-item label="Nombre" prop="nombre">
        <el-input v-model="form.nombre"></el-input>
      </el-form-item>



      <el-form-item label="Proveedor" prop="proveedor">
        <el-input v-model="form.proveedor"></el-input>
      </el-form-item>


      <el-form-item label="Precio" prop="precio">
         <el-input v-model="form.precio"></el-input>
      </el-form-item>

 <el-form-item label="Fecha" prop="fecha">
        <el-input v-model="form.fecha"></el-input>
      </el-form-item>




      <el-form-item>
        <el-button @click="save" type="primary">Guardar</el-button>
      </el-form-item>
    </el-form>
</div>
</template>

<script>
export default {
  name: "InventarioCreateOrUpdate",
  data() {
    return {
      loading: false,
      form: {
        Id: 0,
        Nombre: null,
        Proveedor: null,
        Precio: null,
        Fecha: null
      },
      rules: {
        nombre: [
          { required: true, message: "Debe ingresar un nombre" },
          { min: 3, message: "Debe contener como mínimo 3 caracteres" }
        ],
        proveedor: [{ required: true, message: "El proveedor es requerido" }],
        precio: [{ required: true, message: "Este campo es requerido" }]
      }
    };
  },
  computed: {
    pageTitle() {
      return this.form.Id === 0 ? "Nuevo Articulo" : `${this.form.proveedor}, ${this.form.nombre}`;
    }
  },
  created() {
    let self = this;
    self.get(self.$route.params.id);
  },
  methods: {
    get(id) {
      if(id == undefined) return;

      let self = this;

      self.loading = true;
      self.$store.state.services.InvenService
        .get(id)
        .then(r => {
          self.loading = false;
          self.form.id = r.data.id;
          self.form.nombre = r.data.nombre;
          self.form.proveedor = r.data.proveedor;
          self.form.precio = r.data.precio;
        self.form.fecha = r.data.fecha;
        })
        .catch(r => {
          self.$message({
            message: "Ocurrió un error inesperado",
            type: "error"
          });
        });
    },
    save() {
      let self = this;
      self.$refs["ruleForm"].validate(valid => {
        if (valid) {
          self.loading = true;

          if(self.form.Id > 0) {
            self.$store.state.services.InvenService
            .update(self.form)
            .then(r => {
              self.loading = false;
              self.$router.push('/inventario');
            })
            .catch(r => {
              self.$message({
                message: "Ocurrió un error inesperado",
                type: "error"
              });
            });
          } else {
            self.$store.state.services.InvenService
              .add(self.form)
              .then(r => {
                self.loading = false;
                self.$router.push('/inventario');
              })
              .catch(r => {
                self.$message({
                  message: "Ocurrió un error inesperado",
                  type: "error"
                });
              });
          }
        }
      });
    }
  }
};
</script>