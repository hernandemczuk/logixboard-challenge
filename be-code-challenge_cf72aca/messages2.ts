export const messages = [
  {
    "type": "ORGANIZATION",
    "id": "99f2535b-3f90-4758-8549-5b13c43a8504",
    "code": "BOG"
  },
  {
    "type": "ORGANIZATION",
    "id": "381f5cc5-dfe4-4f58-98ad-116666855ca3",
    "code": "SEA"
  },
  {
    "type": "ORGANIZATION",
    "id": "34f195b5-2aa1-4914-85ab-f8849f9b541a",
    "code": "FMT"
  },
  {
    "type": "ORGANIZATION",
    "id": "34f195b5-2aa1-4914-85ab-f8849f9b541a",
    "code": "NAM"
  },
  {
    "type": "SHIPMENT",
    "referenceId": "S00001167",
    "organizations": ["SEA"],
    "estimatedTimeArrival": "2020-11-21T00:00:00",
    "transportPacks": {
      "nodes": [
        {
          "totalWeight": {
            "weight": "10",
            "unit": "KILOGRAMS"
          }
        },
        {
          "totalWeight": {
            "weight": "2.20",
            "unit": "POUNDS"
          }
        }
      ]
    }
  },
  {
    "type": "SHIPMENT",
    "referenceId": "S00001167",
    "organizations": ["SEA", "NAM"],
    "estimatedTimeArrival": "2020-11-21T00:00:00",
    "transportPacks": {
      "nodes": [
        {
          "totalWeight": {
            "weight": "10",
            "unit": "KILOGRAMS"
          }
        },
        {
          "totalWeight": {
            "weight": "10",
            "unit": "KILOGRAMS"
          }
        },
        {
          "totalWeight": {
            "weight": "10",
            "unit": "KILOGRAMS"
          }
        }
      ]
    }
  },
  {
    "type": "SHIPMENT",
    "referenceId": "S00001175",
    "organizations": ["SEA", "NAM"],
    "transportPacks": {
      "nodes": [
        {
          "totalWeight": {
            "weight": "10",
            "unit": "KILOGRAMS"
          }
        }
      ]
    }
  },
  {
    "type": "SHIPMENT",
    "referenceId": "S00001197",
    "organizations": ["BOG"],
    "estimatedTimeArrival": null,
    "transportPacks": {
      "nodes": [
        {
          "totalWeight": {
            "weight": "10",
            "unit": "KILOGRAMS"
          }
        }
      ]
    }
  },
  {
    "type": "SHIPMENT",
    "referenceId": "S00001175",
    "organizations": ["SEA"],
    "estimatedTimeArrival": "2020-11-20T00:00:00",
    "transportPacks": {
      "nodes": [
        {
          "totalWeight": {
            "weight": "10",
            "unit": "KILOGRAMS"
          }
        },
        {
          "totalWeight": {
            "weight": "2.21",
            "unit": "POUNDS"
          }
        },
        {
          "totalWeight": {
            "weight": "35.274",
            "unit": "OUNCES"
          }
        }
      ]
    }
  }
]