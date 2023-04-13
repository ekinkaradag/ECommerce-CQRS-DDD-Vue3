<template>
    <div class="general-details">
        <p><b>Order Date:</b>
            {{
                new Date(orderDetails.orderDate)
                    .toLocaleDateString('en-GB',
                    {
                        year: 'numeric',
                        month: 'long',
                        day: 'numeric',
                        hour: 'numeric',
                        minute: 'numeric'
                    })
            }}</p>
        <p v-if="!!orderDetails.orderChangeDate"> <b>Order Change Date:</b> 
            {{
                new Date(orderDetails.orderChangeDate)
                    .toLocaleDateString('en-GB',
                    {
                        year: 'numeric',
                        month: 'long',
                        day: 'numeric',
                        hour: 'numeric',
                        minute: 'numeric'
                    })
            }}</p>
        <p><b>Total: </b>€ {{ (orderDetails.price/1).toFixed(2) }}</p>
    </div>
    <div class="product-preview--list">
        <ProductPreviewComponent
            v-for="orderedProduct in orderedProducts"
            v-bind:key="orderedProduct.id"
            :name="orderedProduct.quantity + 'x ' + orderedProduct.name"
            :price="orderedProduct.price"
            :imageUrl="orderedProduct.imageUrl" />
    </div>
</template>

<script lang="js">
import { defineComponent } from 'vue';
import ProductPreviewComponent from '../components/ProductPreviewComponent.vue';

export default defineComponent({
    data() {
      return {
        orderedProducts: [],
        orderDetails: [],
      }
    },
    props: {
        customerId: String,
        id: String,
    },
    created() {
      this.fetchOrderDetails();
    },
    methods: {
        async fetchOrderDetails() {
            const response =
                        await fetch('/api/customers/' +
                                this.customerId +
                                '/orders/' +
                                this.id)
                        .then(r => r.json());
            this.orderDetails = response;
            this.orderedProducts = response.products
        }
    },
    components: {
      ProductPreviewComponent
    }
});
</script>
  
<style scoped>
.general-details {
    text-align: left;
    margin-left: 4px;
}

.product-preview--list {
  display: flex;
  justify-content: space-around;
  flex-wrap: wrap;
  margin-bottom: 50px;
}
</style>
  