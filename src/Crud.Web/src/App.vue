<template>
  <div class="app-div">
    <Person />
    <City />
  </div>
</template>

<script lang="ts">
import Person from "./components/Person/index.vue";
import City from "./components/City/index.vue";
export default {
  components: {
    Person,
    City,
  },
};
</script>

<style>
#app {
  font-family: Roboto, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #0e355d;
  margin-top: 60px;
}

body {
  overflow: hidden;
}

button {
  background-color: #000000;
  color: white;
  align-content: flex-end;
  border: none;
  width: 5em;
  height: 2em;
  font-weight: bold;
}

.app-div {
  width: 100vw;
  height: 100vh;
  display: flex;
  justify-content: center;
  overflow: none;
  gap: 1em;
}
</style>
