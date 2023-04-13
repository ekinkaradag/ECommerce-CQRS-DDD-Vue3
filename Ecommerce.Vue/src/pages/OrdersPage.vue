<template>
  <div class="post">
    <div v-if="loading" class="loading">Loading...</div>
    <h1 >Here are your orders, {{ username }}</h1>
    <Table
      localStorageKey="ordersTable"
      noDataText="No orders yet"
      :dataSource="dataSource"
      :columns="columns"
      :baseDetailsRoute="{name: 'Order Details', params: {customerId: id}}"
    />
  </div>
</template>

<script lang="js">
import { defineComponent } from 'vue';
import Table from '../components/TableComponent.vue'

export default defineComponent({
    components: {
    Table,
},
    data() {
        return {
            loading: false,
            orders: null,
            username: '',
            dataSource: {
                fetchAll: async () => {
                    return await fetch('/api/customers/' + this.id + '/orders')
                    .then(r => r.json())
                }
            },
            columns: [
                {
                  dataField: 'orderDate',
                  caption: 'Date',
                  dataType: 'datetime',
                  format: 'HH:mm, dd MMM yyyy'
                },
                {
                  dataField: 'price',
                  caption: 'Total Price',
                  format: { style: 'currency', currency: 'EUR' },
                  precision: 2
                },
                {
                  dataField: 'isRemoved',
                  caption: 'Cancelled',
                },
                {
                  dataField: '',
                  caption: '',
                  cellTemplate: 'commands'
                }

            ]
        };
    },
    created() {
      this.fetchUserName();
    },
    methods:{
      async fetchUserName() {
        const response =
          await fetch('/api/customers/' + this.id)
          .then(r => r.json())
          this.username = response.name;
          return response;
      }
    },
    props: {
        id: String,
        lastName: String
    },

});
</script>
<style>
.dx-datagrid-rowsview .order {  
    text-align: center!important;  
} 
</style>
