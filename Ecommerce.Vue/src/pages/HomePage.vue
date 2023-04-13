<template>
  <div class="post">
    <div v-if="loading" class="loading">Loading...</div>
    
    <h1>Products</h1>
    <ProductPreviewListComponent :items="products" />
  </div>
</template>

<script lang="js">
import { defineComponent } from 'vue';
import ProductPreviewListComponent from '@/components/ProductPreviewListComponent.vue';

export default defineComponent({
    components: {
    ProductPreviewListComponent
},
    data() {
        return {
            loading: false,
            products: null,
        };
    },
    methods:{
      async fetchProducts() {
        const response = await fetch('/api/products')
          .then(r => r.json());
        this.products = response;
      }
    },
    created() {
      this.fetchProducts();
    },
    props: {
        id: String,
        username: String,
        lastName: String
    },

});
</script>
