<template>
<div>
    <h2>Articulos</h2>
    <el-table v-loading="loading" :data="data" style="width: 100%">


        <el-table-column prop="nombre" label="Nombre" sortable>

          <template slot-scope="scope">
            {{ scope.row.nombre }}, {{ scope.row.name }}
          </template>
        </el-table-column>

        <el-table-column prop="precio" label="Precio" width="500" sortable></el-table-column>
        <el-table-column align="right">
          <template slot-scope="scope">
            <el-button type="danger" @click="remove(scope.row.id)">Eliminar</el-button>
            <el-button @click="$router.push(`/inventario/${scope.row.id}/edit`)">Editar</el-button>
          </template>
        </el-table-column>
      </el-table>


</div>
</template>

<script>
export default {
  name: "InventarioIndex",
  data() {
    return {
      data: [],
      loading: false
    };
  },
  created() {
    let self = this;
    self.getAll();
  },
  methods: {
    getAll() {
      let self = this;

      self.loading = true;

      self.$store.state.services.InvenService
        .getAll()
        .then(r => {
          self.loading = false;
          self.data = r.data;
        })
        .catch(r => {
          self.$message({
            message: "Ocurrió un error inesperado",
            type: "error"
          });
        });
    },
    remove(id) {
      let self = this;

      self
        .$confirm("Esta seguro de realizar esta acción?", "Confirmación", {
          confirmButtonText: "Si",
          cancelButtonText: "Cancelar",
          type: "warning"
        })
        .then(() => {
          _remove();
        })
        .catch(() => {});

      function _remove() {
        self.$store.state.services.InvenService
          .remove(id)
          .then(r => {
            self.loading = false;
            self.getAll();
          })
          .catch(r => {
            self.$message({
              message: "Ocurrió un error inesperado",
              type: "error"
            });
          });
      }
    }
  }
};
</script>