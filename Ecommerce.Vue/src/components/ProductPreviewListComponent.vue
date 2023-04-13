<template>
  <div class="toolbar">
    <DxSelectBox
      :items="sortingValues"
      v-model:value="sortSelection"
      width="200px"
      class="sort--select-box"/>
  </div>
  <div class="product-preview--list">
    <ProductPreviewComponent
      v-for="product in products"
      v-bind:key="product.id"
      :name="product.name"
      :price="product.price"
      :imageUrl="product.imageUrl"
    />
  </div>
</template>

<script lang="js">
import { defineComponent } from 'vue';
import DxSelectBox from 'devextreme-vue/select-box';
import ProductPreviewComponent from './ProductPreviewComponent.vue';

export default defineComponent({
    data() {
      const sortingValues = ['Price: Ascending', 'Price: Descending'];
      return {
        sortingValues,
        sortSelection: sortingValues[0],
      }
    },
    props: {
        items: Array,
    },
    computed: {
      products: function () {
          if (this.sortSelection === this.sortingValues[0])
            return [...this.items].sort((a, b) => (a.price > b.price) ? 1 : -1)
          return [...this.items].sort((a, b) => (a.price < b.price) ? 1 : -1)
        }
    },
    components: {
      DxSelectBox,
      ProductPreviewComponent
    }
});
</script>

<style scoped>
.product-preview--list {
  display: flex;
  justify-content: space-around;
  flex-wrap: wrap;
  margin-bottom: 50px;
}

.toolbar {
  width: 100%;
  display: flex;
}
.sort--select-box{
  float: right;
}
</style>
