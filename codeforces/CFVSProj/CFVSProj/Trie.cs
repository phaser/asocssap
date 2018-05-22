using System;
using System.Collections.Generic;
using System.Text;

class TrieNode
{
    public char c;
    public bool isLeaf;
    public List<TrieNode> children;

    public TrieNode()
    {
        children = new List<TrieNode>();
    }
}

public class Trie
{
    TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    public void AddKey(string key)
    {
        var cn = root;
        foreach (char c in key)
        {
            var child = GetChild(c, cn);
            if (child == null)
            {
                var newNode = new TrieNode() { c = c };
                cn.children.Add(newNode);
                cn = newNode;
            }
            else
            {
                cn = child;    
            }
        }
        cn.isLeaf = true;
    }

    private TrieNode GetChild(char c, TrieNode n)
    {
        foreach (var child in n.children)
        {
            if (child.c == c)
            {
                return child;
            }
        }
        return null;
    }

    public bool HasKey(string key)
    {
        var cn = root;
        foreach (var c in key)
        {
            var child = GetChild(c, cn);
            if (child == null)
            {
                return false;
            }
            cn = child;
        }
        if (cn.isLeaf == false)
            return false;
        return true;
    }
}

namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_Trie
    {
        [TestMethod]
        public void Test1()
        {
            Trie trie = new Trie();
            trie.AddKey("there");
            trie.AddKey("their");
            trie.AddKey("home");
            trie.AddKey("house");
            Assert.IsTrue(trie.HasKey("there"));
            Assert.IsTrue(trie.HasKey("their"));
            Assert.IsTrue(trie.HasKey("home"));
            Assert.IsTrue(trie.HasKey("house"));
            Assert.IsFalse(trie.HasKey("ho"));
            Assert.IsFalse(trie.HasKey("zen"));
            Assert.IsFalse(trie.HasKey("hom"));
            Assert.IsFalse(trie.HasKey("the"));
            trie.AddKey("the");
            Assert.IsTrue(trie.HasKey("the"));
        }
    }
}
