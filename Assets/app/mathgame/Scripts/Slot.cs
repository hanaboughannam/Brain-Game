using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Relationship_BS relationship;

    public string getValue()
    {
        if (this.relationship != null && this.relationship.isActive)
            return this.relationship.block.getValue();
        return "";
    }

    internal void EndRelationship()
    {
        this.relationship = null;
    }

    internal void Divorce()
    {
        this.relationship.block.EndRelationship();
        EndRelationship();
    }
}
