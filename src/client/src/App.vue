<script setup lang="ts">

  import { ref } from 'vue';

  let pizzaId = ref<number>(0);
  let pizza = ref<any>({ });

  async function loadFullPizzaInfo(pizzaOffset: number) {
    pizzaId.value += pizzaOffset;
    if (pizza.value <= 0) {
      return;
    }
    const pizzaResponse = await fetch(`http://localhost:5059/api/pizzas/info/${pizzaId.value}`);
    const pizzaData = await pizzaResponse.json();
    pizza.value = pizzaData;
    console.log(pizza.value);
  }

</script>

<template>

  <div>
    <button v-if="pizzaId > 0" @click="loadFullPizzaInfo(-1)">Prev</button>
    <button @click="loadFullPizzaInfo(1)">Next</button>
  </div>

  <h1>{{ pizza.pizzaName }}</h1>

  <ul>
    <li v-for="(ingredient, index) in pizza.ingredients" :key="index">
      <span v-if="ingredient.useExtraAmount" class="bold">Extra {{ ingredient.name }}</span>
      <span v-else>{{ ingredient.name }}</span>
    </li>
  </ul>
</template>

<style scoped>
.bold {
  font-weight: bold;
}

li {
  list-style-type: none;
}

</style>
