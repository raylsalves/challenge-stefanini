<template>
  <div>
    <button class="add-button-person" @click="show">Add Person</button>
    <PersonModal :show="personModal" />
    <PersonTable :persons="persons" />
  </div>
</template>

<script lang="ts">
import axios from "axios";
import { defineComponent } from "@vue/runtime-core";
import PersonTable from "./PersonTable.vue";
import PersonModal from "./PersonModal.vue";
import { useStore } from "../../store";
import { mapGetters } from "vuex";

export default defineComponent({
  async mounted() {
    const response = await axios({
      method: "GET",
      url: "http://localhost:5000/api/Person",
    });

    this.store.commit("setPersons", response.data.persons);
  },
  setup() {
    const store = useStore();
    return {
      store,
    };
  },
  components: {
    PersonTable,
    PersonModal,
  },
  methods: {
    show() {
      this.store.commit("togglePersonModal");
    },
  },
  computed: {
    ...mapGetters({
      personModal: "getPersonModal",
      persons: "getPersons",
    }),
  },
});
</script>

<style>
.add-button-person {
  width: 30%;
  height: 2em;
  display: block;
  background-color: #0f2699;
}
</style>
