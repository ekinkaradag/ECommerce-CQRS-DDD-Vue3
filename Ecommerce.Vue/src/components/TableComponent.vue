<template>
  <DxDataGrid
    :data-source="customStore"
    :remote-operations="false"
    :allow-column-reordering="true"
    :row-alternation-enabled="true"
    :show-borders="true"
    :no-data-text="noDataText"
  >
    <DxColumnFixing :enabled="true" />
    <DxSearchPanel :visible="true" :width="300" />
    <DxHeaderFilter :visible="true" />
    <DxFilterRow :visible="true" />
    <DxFilterPanel :visible="true" />
    <DxStateStoring
      :enabled="true"
      type="localStorage"
      :storage-key="localStorageKey ?? ''"
    />
    <DxPager
      :allowed-page-sizes="[10, 20, 50, 100]"
      :show-page-size-selector="true"
      :show-info="true"
      :visible="true"
    />
    <DxPaging :page-size="10" />
    <DxColumn
      v-for="column in columns"
      :key="column.cellTemplate"
      v-bind="column"
      alignment="left"
    >
      <DxLookup
        v-if="column.lookupData"
        :data-source="{ store: column.lookupData, sort: 'name' }"
        value-expr="id"
        display-expr="name"
      />
    </DxColumn>
    <template #commands="{ data }">
      <router-link :to="{...baseDetailsRoute, params:{id:data.data.id, ...baseDetailsRoute.params}}">Details</router-link>
    </template>
  </DxDataGrid>
</template>

<script lang="js">
import { defineComponent } from 'vue';
import {
  DxDataGrid,
  DxColumnFixing,
  DxHeaderFilter,
  DxFilterRow,
  DxFilterPanel,
  DxStateStoring,
  DxColumn,
  DxPager,
  DxPaging,
  DxLookup,
  DxSearchPanel,
} from 'devextreme-vue/data-grid';

import CustomStore from 'devextreme/data/custom_store';

export default defineComponent({
    components: {
        DxDataGrid,
        DxColumnFixing,
        DxHeaderFilter,
        DxFilterRow,
        DxFilterPanel,
        DxStateStoring,
        DxColumn,
        DxPager,
        DxPaging,
        DxLookup,
        DxSearchPanel
    },
    data() {
        return {
            customStore: new CustomStore({
                key: 'id',
                load: () => this.dataSource.fetchAll(),
              }),
          };
    },
    methods:{
      async fecthData(){
        const response = await this.dataSource.fetchAll();
        return response.data;
      },

      getDetailsRoute(row) {
        let route = this.baseDetailsRoute;
        route.params.push({id: row.data.id})
        return route;
      }
    },
    props: {
        localStorageKey: String,
        columns: Array,
        dataSource: Object,
        noDataText: String,
        baseDetailsRoute: Object,
    },
});
</script>
