<template>
  <div class="person-modal" v-if="show">
    <div class="person-form">
      <div class="person-inputs">
        <input type="text" placeholder="Name" v-model="personData.name" />
        <input type="text" placeholder="CPF" v-model="personData.cpf" />
        <input type="text" placeholder="Age" v-model="personData.age" />
        <input
          type="text"
          placeholder="City Id"
          v-model="personData.cityId"
        />
      </div>
      <div class="person-actions">
        <button @click="sendRequest">Submit</button>
        <button class="delete-person" @click="cancel">Cancel</button>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "@vue/runtime-core";
import axios from "axios";
import { useStore } from "../../store";
import { mapGetters } from "vuex";

export default defineComponent({
  setup() {
    const store = useStore();
    return {
      store,
    };
  },
  data() {
    return {
      personData: {
        name: "",
        cpf: "",
        age: 0,
        cityId: "",
      },
      style: true,
    };
  },
  props: {
    show: {
      type: Boolean,
      default: false,
    },
  },
  computed: {
    ...mapGetters({
      persons: "getPersons",
      editFlag: "getEditFlag",
      editId: "getEditId",
      personEdit: "getPersonEdit",
      personModal: "getPersonModal",
    }),
  },
  methods: {
    async sendRequest() {
      const data = this.personData;
      console.log(this.editFlag);
      if (this.editFlag) {
        await axios({
          method: "PUT",
          url: `http://localhost:5000/api/Person/${this.editId}`,
          data,
        });

        this.store.commit("toggleEdit");
        const mp = this.store.state.persons;
        const np = mp.map((item) => {
          console.log(item);
          if (item.id === this.editId) {
            item = {
              ...data,
              id: this.editId,
            };
          }
          return item;
        });
        this.store.commit("setPersons", np);
        this.store.commit("togglePersonModal");
        this.personData = {
          name: "",
          cpf: "",
          age: 0,
          cityId: "",
        };
        this.store.commit("setEditPerson", this.personData);
      } else {
        const response = await axios({
          method: "POST",
          url: "http://localhost:5000/api/Person",
          data,
        });

        const mp = this.store.state.persons;

        mp.push({
          ...data,
          id: response.data.id as string,
        });
        this.store.commit("setPersons", mp);

        this.personData = {
          name: "",
          cpf: "",
          age: 0,
          cityId: "",
        };
        this.store.commit("setEditPerson", this.personData);
        this.store.commit("togglePersonModal");
      }
      //window.location.reload();
    },
    cancel() {
      this.personData = {
        name: "",
        cpf: "",
        age: 0,
        cityId: "",
      };
      this.store.commit("setEditPerson", this.personData);
      this.store.commit("togglePersonModal");
    },
  },
});
</script>

<style>
.person-modal {
  position: absolute;
  top: 0;
  left: 0;
  z-index: 1;
  display: flex;
  align-items: center;
  justify-content: center;

  margin: 0 !important;

  width: 100%;
  height: 100%;

  background-color: rgba(0, 0, 0, 0.4);
}

.person-form {
  display: flex;
  flex-direction: column;
  background-color: white;
  padding: 2em;
  gap: 2.5em;
}

.person-inputs {
  display: flex;
  flex-direction: column;
  gap: 1.5em;
}

.person-actions {
  display: flex;
  align-items: flex-end;
  justify-content: center;
  gap: 1em;
}

.delete-Person {
  background-color: #f93e3e;
}

</style>
