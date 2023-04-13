<template>
  <div class="product-preview">
    <img class="product-image" :src="imageUrl" />
    <div class="product-preview--footer">
      <span class="name">{{name}}</span>
      <span class="price">€ {{formatPrice(price)}}</span>
    </div>
  </div>
</template>

<script lang="js">
import { defineComponent } from 'vue';

export default defineComponent({
    props: {
        imageUrl: String,
        name: String,
        price: Number
    },
    methods: {
      formatPrice(value) {
        return (value/1).toFixed(2).toString();
      }
    }
});
</script>

<style scoped>
.product-preview {
  width: 250px;
  min-width: 250px;
  padding: 8px;
  margin-top: 16px;
  display: flex;
  flex-direction: column;
  height: 350px;
  align-items: center;
  box-shadow: 0px 0px 10px black;
}
.product-preview .product-image {
  width: 100%;
  height: 95%;
  min-width: 224px;
  background-size: cover;
  background-position: center;
  border: 1px solid #ddd;
  margin-bottom: 5px;
  object-fit: cover;
}

.product-preview .product-preview--footer {
  width: 100%;
  height: 5%;
  display: flex;
  justify-content: space-between;
  font-size: 16px;
}
.product-preview--footer .name {
  width: 70%;
  margin-bottom: 15px;
  text-align: left;
}

.product-preview--footer .price {
  width: 30%;
  text-align: right;
}
</style>
