<template>
  <table class="styled-table">
    <thead>
      <tr>
        <th>Id</th>
        <th>Name</th>
        <th>UF</th>
        <th>Edit | Delete</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in cities" :key="item.id">
        <td>{{ item.id }}</td>
        <td>{{ item.name }}</td>
        <td>{{ item.uf }}</td>
        <td class="table-actions">
          <button @click="edit(item)">Edit</button>
          <button class="delete-city" @click="remove(item.id)">Delete</button>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script lang="ts">
import { defineComponent, PropType } from "vue";
import { mapGetters } from "vuex";
import { useStore } from "../../store";
import axios from "axios";
import { City } from "../../types";

export default defineComponent({
  setup() {
    const store = useStore();
    return {
      store,
    };
  },
  props: {
    cities: {
      type: [] as PropType<City[]>,
    },
  },
  methods: {
    async remove(id: string) {
      await axios({
        method: "DELETE",
        url: `http://localhost:5000/api/City/${id}`,
      });

      const mp = this.store.state.cities;

      const np = mp.filter((item) => item.id !== id);

      console.log(np);

      this.store.commit("setCities", np);
      //window.location.reload();
    },
    edit(city: City) {
      this.store.commit("setEditId", city.id);
      this.store.commit("setEditCity", city);
      this.store.commit("toggleCityModal");
      this.store.commit("toggleEdit");
    },
  },
});
</script>

<style>
.styled-table {
  border-collapse: collapse;
  margin: 25px 0;
  font-size: 0.9em;
  font-family: sans-serif;
  min-width: 400px;
  box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
}

.styled-table thead tr {
  background-color: #0c0098;
  color: #ffffff;
}

.styled-table th,
.styled-table td {
  padding: 12px 15px;
}

.styled-table tbody tr {
  border-bottom: thin solid #dddddd;
}

.styled-table tbody tr:nth-of-type(even) {
  background-color: #f3f3f3;
}

.styled-table tbody tr:last-of-type {
  border-bottom: 2px solid #009879;
}

.styled-table tbody tr.active-row {
  font-weight: bold;
  color: #009879;
}

.table-actions {
  display: flex;
  gap: 1em;
}

.delete-city {
  background-color: #f93e3e;
}
</style>
