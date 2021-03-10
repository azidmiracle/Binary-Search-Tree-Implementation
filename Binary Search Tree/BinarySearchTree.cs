using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binary_Search_Tree
{
    public class BSTNode//class for my node
    {
        public int Value
        {
            get; set;
        }

        public BSTNode ParentNode;//PARENT OF A NODE
        public BSTNode LeftNode;//PARENT'S LEFT CHILD
        public BSTNode RightNode;//PARENT'S RIGHT CHILD

        public BSTNode(int value)//this is the node 
        {
            Value = value;
            ParentNode = null;//SET THE PARENT TO NULL
            LeftNode = null;//SET THE LEFT CHILD TO NULL
            RightNode = null;//SET THE RIGHT CHILD TO NULL
        }

    }

    public class BinarySearchTree//class for my BST. All methods are here
    {

        //my global variables
        public BSTNode Root;       
        public BSTNode SearchNode=null;
        public int count = 0; //count for duplicates
        public bool isFound;//initialize this boolean. used for search method. If Value is found, it will return True
        string printData;//i saved the ascending order of values here

        //----------------INSERT Value IN TO THE BST-----------------------
        public void InsertNodeNonRC(BinarySearchTree MyTree, int val)
        {
            if (MyTree.Root == null)//if the tree is empty, insert the node at the root
            {
                //insert in the root
                BSTNode root = new BSTNode(val);
                MyTree.Root = root;//make it as the ROOT of the tree
                MessageBox.Show("Inserted Root");
                return;//return to the caller once inserted
            }

            //if not null then set the root as the current node
            BSTNode CurrentNode = MyTree.Root;//start from the Root

            bool isInsert = false;//set this boolean to false since Value is not inserted

            do//execute the codes below while isInsert is equals to false
            {
                if (val < CurrentNode.Value)//if the Value to be inserted is less than the current node
                {
                    //traverse left sub tree
                    if (CurrentNode.LeftNode == null)//if the left subtree is null, then insert the Value
                    {

                        BSTNode NewNode = new BSTNode(val);//create new leaf node
                        CurrentNode.LeftNode = NewNode;//put the leaf node to the left of the currentnode
                        NewNode.ParentNode = CurrentNode;//set the Current Node as the parent of the inserted leaf node
                        isInsert = true;//set the isInsert to true
                    }

                    else//if the current node is not the leaf node, then traverse again to its left sub tree 
                    //until the leaf node is reached
                    {
                    
                        CurrentNode = CurrentNode.LeftNode;
                    }

                }
                if (val >= CurrentNode.Value)//if the Value to be inserted is greater than or equal to the current node
                {
                    //traverse right sub tree
                    if (CurrentNode.RightNode == null)//if the right subtree is null, then insert the Value
                    {

                        BSTNode NewNode = new BSTNode(val);//create new leaf node
                        CurrentNode.RightNode = NewNode;//put the leaf node to the right of the currentnode
                        NewNode.ParentNode = CurrentNode;//set the Current Node as the parent of the inserted leaf node
                        isInsert = true;//set the isInsert to true

                    }

                    else//if the current node is not the leaf node, then traverse again to its right sub tree 
                    //until the leaf node is reached
                    {
                        CurrentNode = CurrentNode.RightNode;
                    }

                }


            } while (!isInsert);//exit the loop when the Value is inserted in the tree

           MessageBox.Show(val + " is inserted successfully in the tree.");

        }

        //END OF ----------------INSERT Value IN TO THE BST-----------------------



        //----------------SEARCH Value IN TO THE BST------------------------------
        public void Search(BinarySearchTree MyTree, int val)
        {

            if (Root == null)//if the tree has no elements, prompt tree is empty
            {
                SearchNode = null;//set the global variable SearchNode to null

                isEmpty();
            }
            else// if the root is not null
            {
                SearchRecursive(MyTree, Root, val);//call this method
            }
            //return here after SearchRecursive is finished
            if (isFound == true && Root != null)//if the isFound is true and the tree is not empty
            {
                DisPlayVal(SearchNode, "Data found ");//display the Value that is searched
            }
            else if(isFound == false && Root != null)//if the isFound is false and the tree is not empty
            {
                MessageBox.Show("Cannot find  " + val + " in the tree.");//pop up this message
            }
        }
        //END OF----------------SEARCH Value IN TO THE BST------------------------------


        //THIS IS THE SUBROUTINE CALL for Search METHOD    
        public void SearchRecursive(BinarySearchTree MyTree, BSTNode CurrentNode, int val)//search the Value using non-recursive method
        {

            //this is the terminating condition if the Value is not found in the tree
            if (CurrentNode == null)//if the current node is null, return to Search caller
            {
                isFound = false;//cannot find the Value . set this global variable to false
                return;//return to caller
            }
            //this is the terminating condition if the Value is found in the tree
            if (val == CurrentNode.Value)//if the value is equal the current node, meaning the Value is found
            {
                SearchNode = CurrentNode;//set the global variable SearchNode with currentNode
                isFound = true;//set this global variable to true
                return;
            }
            else//if the above two conditions is not yet met, do the recursion below. traverse the tree
            {
                if (val < CurrentNode.Value)//if the value is less than the current node, traverse left
                {

                    SearchRecursive(MyTree, CurrentNode.LeftNode, val);//traverse left

                }
                if (val > CurrentNode.Value)//if the value is greater than the current node, traverse right
                {

                    SearchRecursive(MyTree, CurrentNode.RightNode, val);//traverse right

                }

            }

        }


        //----------------GET THE MINIMUM VALUE IN THE BST------------------------------
        public void Minimum(BinarySearchTree mytree)//minimum is always at the left subtree of a tree
        {
            BSTNode minVal = getMinimum(mytree, Root);//call the getMinimum subroutine 
            //after calling the subroutine is finished, return here

            if (minVal != null)//when the returned value is not null
            {
                DisPlayVal(minVal, "Minimum ");//display the Value that is searched               
            }
            else//if the returned value is null
            {
                isEmpty();
            }
        }

        //----------------GET THE MAXIMUM VALUE IN THE BST------------------------------
        public void Maximum (BinarySearchTree mytree)//maximum is always at the right subtree of a tree
        {
            BSTNode maxVal = getMaximum(mytree, Root);//call the getMaximum subroutine 
            //after calling the subroutine is finished, return here

            if (maxVal != null)//when the returned value is not null
            {
                DisPlayVal(maxVal, "Maximum ");//display the Value that is searched    
            }
            else//if the returned value is null
            {
                isEmpty();
            }

        }


//---------------GET THE SUCCESSOR OF THE NODE THAT IS BEING SEARCHED------------------
        public void Successor(BinarySearchTree mytree, int val)
        {
           SearchRecursive(mytree, Root,val);//call the SearchRecursive subroutine

            //after the callee is finisned, return here

            if (Root == null)//if the tree is empty (Root is null)
            {
                isEmpty();//call this procedure to display

                return;
            }

            if (isFound == false)//when cannot find the Value in the BST
            {
                MessageBox.Show("Cannot find " + val);

                return;
            }

           if (isFound==true)//if can find the Value
            {
                BSTNode successor = getSuccessor(mytree,val, null);//call the subRoutine getSuccessor and store the returned value

                if (successor != null)//if the returned value is not null
                {
                    DisPlayVal(successor, "Successor ");//display the Value that is searched    
                }

                else//if the returned value is  null
                {
                    MessageBox.Show("No successor");
                }

            }

                    
        }


        //-----------------------BST PREDECESSOR METHOD--------------------
        public void Predecessor(BinarySearchTree mytree, int val)//this is a reverse process of predecessor
        {
            SearchRecursive(mytree, Root, val);//use the search method

            if (Root == null)//if the tree is empty (Root is null)
            {
                isEmpty();

                return;
            }

            if (isFound == false )//if cannot find the Value then return
            {
                MessageBox.Show("Cannot find " + val);

                return;
            }

            if (Root != null && isFound == true)//if the Value if found and the tree is not empty
            {
                BSTNode predecessor = getPredecessor(mytree,val, null);//call the getPredecessor subroutine and store the returned value

                if (predecessor != null)//if the returned value is not null
                {
                    DisPlayVal(predecessor, "Predecessor ");//display the Value that is searched   
                }

                else//if the returned value is  null
                {
                    MessageBox.Show("No Predecessor");
                }

            }

        }

        //--------------BST DELETE METHOD------------------
        public void Delete(BinarySearchTree mytree, int val)//main method for delete
        {
            SearchRecursive(mytree, Root, val);//searched the value to be deleted

            if (isFound == true)
            {
                count = count + 1;//count how many duplicates
            }
        
            bool isDeleted=false;

            if (Root == null)
            {
                isEmpty();
                return;
            }

            if (isFound == false)
            {               
                if (count == 0)//if count is 0, meaning the Value is not in the BST at all
                {
                    MessageBox.Show("Cannot find " + val);
                }

                if (count > 1)//just pop up that all the dupliates are being removed from the BST
                {
                    MessageBox.Show("No found duplicates.");
                }
              
                return;
            }

           isDeleted = getDelete(mytree, SearchNode, val, false);// call the getDelete subroutine and store the returned value (true or false)

            if (isDeleted == true)
            {
                MessageBox.Show(val + " has been successfully deleted.");
              
            }

            Delete(mytree, val);//recursive call. to check for duplicates until no more Value is found

        }

        public bool getDelete(BinarySearchTree mytree, BSTNode deleteNode, int val, bool IsDeleted)
        {

            //deleteNode = SearchNode;//put the searchnode node as the node to be deleted

            if (deleteNode != null)//execute the followind codes if the node to be deleted is found 
                                   //in the tree and it is not the root. Root has null value for parent
            {
                BSTNode parent_node = deleteNode.ParentNode;//save the parent of the node to be deleted

                //CASE 1: NODE TO DELETE WITH NO CHILDREN

                if (deleteNode.LeftNode == null && deleteNode.RightNode == null)//IT IS THE LEAF NODE
                {
                    DeleteNodeNoChild(parent_node, deleteNode);//CALL THE METHOD FOR NO CHILD                    
                    IsDeleted = true;//return true

                }
                //CASE 2: NODE TO DELETE HAS ONE CHILD ETHIER LEFT OR RIGHT CHILD
                else if ((deleteNode.LeftNode == null || deleteNode.RightNode == null))
                {
                    DeleteNodeOneChild(parent_node, deleteNode);//CALL THE METHOD FOR ONE CHILD
                    IsDeleted = true;//return true
                }

                //CASE 3: both has right and left children
                else if (deleteNode.LeftNode != null && deleteNode.RightNode != null)
                {

                    BSTNode SucessorNode = getSuccessor(mytree, val, null);//get the successor node of the node to be deleted

                    //CHECK THE CHILDREN OF THE SUCCESSOR NODE
                    //case a: if successor has no child
                    if (SucessorNode.RightNode == null && SucessorNode.LeftNode == null)
                    {

                        //swapp the value of the two nodes (NODE TO BE DELETED AND THE SUCCESSOR NODE)
                        int temporaryDeleteNodeData = deleteNode.Value;
                        deleteNode.Value = SucessorNode.Value;//put the value of the successor Value to the node to be deleted
                        SucessorNode.Value = temporaryDeleteNodeData;//put the Value of the Value of the node to be deleted to the successor node
                        
                        //do the case no child 
                        DeleteNodeNoChild(SucessorNode.ParentNode, SucessorNode);//delete the successor node
                        IsDeleted = true;//return true
                    }
                    //case b: if succesor has right child (at most child)
                    else if (SucessorNode.RightNode != null)
                    {
                        //swapp the value of the two nodes
                        int temporaryDeleteNodeData = deleteNode.Value;
                        deleteNode.Value = SucessorNode.Value; //put the value of the successor node to the node to be deleted
                        SucessorNode.Value = temporaryDeleteNodeData;//now the value of the successor node is the node to be deleted value
                        //do the case no child 
                        DeleteNodeOneChild(SucessorNode.ParentNode, SucessorNode);//call DeleteNodeOneChild procedure  
                        IsDeleted = true;//return true
                    }
                }

            }

            return IsDeleted;
        }

        //------------------SUBROUTINE FOR NODE WITH NO CHILDREN
        public void DeleteNodeNoChild(BSTNode parent_node, BSTNode Deletenode)
        {

            //CHECK IF THE NODE IS THE ROOT OR NOT

            //IF THE NODE IS NOT THE ROOT
            if (parent_node != null)
            {
                if (Deletenode == parent_node.LeftNode)//check if the node to be deleted is the left child of the parent node
                {
                    parent_node.LeftNode = null;//cut the link from its left child


                }
                else if (Deletenode == parent_node.RightNode)//check if the node to be deleted is the right child of the parent node
                {
                    parent_node.RightNode = null;//cut the link from its right child

                }
            }

            //IF THE NODE IS  THE ROOT
            if (parent_node == null && Root==Deletenode)
            {
                Root = null;//set the Root to null;

            }

        }

        //------------------SUBROUTINE FOR NODE WITH ONE CHILD-------------------
        public void DeleteNodeOneChild(BSTNode parent_node, BSTNode DeleteNode)
        {

            if (parent_node != null)//if the the deleted node has parent, do the following
            {
                if (DeleteNode.LeftNode == null && DeleteNode.RightNode != null)//if the node to delete has right child
                {
                    //get the grand parent of its parent
                    if (DeleteNode == parent_node.LeftNode)//check if the deleted node is the left child of its parent
                    {
                        //cut the link of the parent node to the node to be deleted
                        parent_node.LeftNode = DeleteNode.RightNode;//make the RightNode of the node to be deleted as the left child of its parent
                        parent_node.LeftNode.ParentNode = parent_node;//then the grandparent becomes its parent
                    }

                    else if (DeleteNode == parent_node.RightNode)//check if the deleted node is the right child of its parent
                    {
                        //cut the link of the parent node to the node to be deleted
                        parent_node.RightNode = DeleteNode.RightNode;//make the RightNode of the node to be deleted as the right child of its parent
                        parent_node.RightNode.ParentNode = parent_node;//then the grandparent becomes its parent
                    }
                }

                else if (DeleteNode.RightNode == null && DeleteNode.LeftNode != null)//if the node to delete has left child
                {
                    //get the grand parent of its parent
                    
                    if (DeleteNode == parent_node.LeftNode)//check if the deleted node is the left child of its parent
                    {
                        //cut the link of the parent node to the node to be deleted
                        parent_node.LeftNode = DeleteNode.LeftNode;//make the left child of the node to be deleted as the left child of its parent
                        parent_node.LeftNode.ParentNode = parent_node;//then the grandparent becomes its parent

                    }

                    if (DeleteNode == parent_node.RightNode)//check if the deleted node is the right child of its parent
                    {
                        parent_node.RightNode = DeleteNode.LeftNode;//make the LeftNode of the node to be deleted as the right child of its parent
                        parent_node.RightNode.ParentNode = parent_node;//then the grandparent becomes its parent

                    }
                }

            }

            if (parent_node == null)//if the parent of deleted node is the root
            {
                if (DeleteNode.LeftNode == null && DeleteNode.RightNode != null)//if the deleted node is the right child of the root
                {
                    //JUST CUT THE LINK

                    Root = DeleteNode.RightNode;//make the right child as the new root
                    Root.ParentNode = null;//root has no parent

                }

                else if (DeleteNode.RightNode == null && DeleteNode.LeftNode != null)//if the deleted node is the left child of the root
                {
                    Root = DeleteNode.LeftNode;//make the left child as the new root
                    Root.ParentNode = null;//root has no parent

                }

            }

        }


        //---------------THIS IS MY CALLEE FOR MY CALLERS Maximum and getPrecedecessor---------------
        public BSTNode getMaximum(BinarySearchTree mytree, BSTNode root)//it will return the node with a  maximum value
        {
            if (root == null)//if tree is empty, return this value
            {
                return null;//since the root is null, return the node as null
            }

            while (root.RightNode != null)//visit all the right child until it's right is null
            {
                root = root.RightNode;
                //once the root's RightNode is null, it will exit from the WHILE loop
            }

            return root;//return the rightmost leaf node of the root
            //RETURN TO THE CALLER 
        }


        //---------------THIS IS MY CALLEE FOR MY CALLERS Minimum and getSuccessor---------------
        public BSTNode getMinimum(BinarySearchTree mytree, BSTNode root)//it will return the node with a  minimum value
        {
            if (root == null)//if tree is empty, return this value
            {
                return null;//since the root is null, return the node as null
            }

            else//if not null, then traverse to its left subtree
            {
                while (root.LeftNode != null)//visit all the left child until it's left is null
                {
                    root = root.LeftNode;
                    //once the root's LeftNode is null, it will exit from the WHILE loop
                }

            }
            return root;//return the leftmost leaf node of the root
            //RETURN TO THE CALLER 
        }


        //--------------------THIS IS THE CALLEE FOR CALLERs getDelete AND Successor-----------------
        public BSTNode getSuccessor(BinarySearchTree mytree,  int val, BSTNode Successor)
        {
            //THREE CASES IN GETTING THE SUCCESSOR

            //1.) when the node of the Value to be searched has both right and left subtree
            // its successor its always its MINIMUM value of its right sub tree
            if (SearchNode != null && SearchNode.RightNode != null)
            {
                Successor = getMinimum(mytree, SearchNode.RightNode);//use the getMinimum method and save the node
            }

            //CASE WHEN NO RIGHT CHILD AND ITS NOT THE ROOT OF THE TREE
            //BECASUE ParentNode IS ALWAYS NULL NOT WHEN THE SEARCHED NODE IS THE ROOT
            else if (SearchNode != null && SearchNode.RightNode == null && SearchNode.ParentNode != null)
            {
                //2a. when the node of the Value to be searched has no right child, and it's the left child of its parent
                if (SearchNode.ParentNode.LeftNode == SearchNode && SearchNode.ParentNode != null)
                {
                    //then successor is ALWAYS it's parent when it has no right child and it is the left child of its parent
                    Successor = SearchNode.ParentNode;

                }

                //2b. when the node of the Value to be searched has no right child, but it's the right child of its parent
                //meaning it has a greater value than its parent, so need to traverse upward until the temporary parent value is greater
                //than the searched node value
                else if (SearchNode.ParentNode.RightNode == SearchNode)
                {
                    BSTNode temporaryParentNode = SearchNode.ParentNode;//save temporarily the value of its parent

                    //traverse up
                    while (SearchNode.Value >= temporaryParentNode.Value && temporaryParentNode != Root)//traverse up 
                                                                                                      //until the temporaryParentNode is greater than or equal the SearchNode Value
                    {
                        temporaryParentNode = temporaryParentNode.ParentNode;
                        Successor = temporaryParentNode;

                    }

                    //but if it traverse up to the ROOT and the root is still lesser than the SearchNode Value
                    //meaning that value is already the MAXIMUM of the BST
                    if (temporaryParentNode == Root && SearchNode.Value > temporaryParentNode.Value)
                    {
                        Successor = null;//cannot find its successor
                    }

                }

            }

            return Successor;//return the Successor node and return to the CALLER
        }

        //--------------------THIS IS THE CALLEE FOR CALLER Predecessor----------------
        public BSTNode getPredecessor(BinarySearchTree mytree,  int val, BSTNode Predecessor)
        {
            //1.) when the node of the Value to be searched haS left subtree
            // its successor its always its Maximum value of its left sub tree
            if (SearchNode != null && SearchNode.LeftNode != null)
            {

                Predecessor = getMaximum(mytree, SearchNode.LeftNode);//use the getMinimum method
            }

            //2. when the node of the Value to be searched has no left child, and it's the right child of its parent

            else if (SearchNode != null && SearchNode.LeftNode == null && SearchNode.ParentNode != null)
            {
                //2a. when the node of the Value to be searched has no right child, and its the left child of its parent

                if (SearchNode.ParentNode.RightNode == SearchNode)
                {
                    Predecessor = SearchNode.ParentNode;

                }

                //2b. when the node of the Value to be searched has no right child, but it's the right child of its parent
                //meaning it has a greater value than its parent, so need to traverse upward until the temporary parent value is greater
                //than the searched node value
                else if (SearchNode.ParentNode.LeftNode == SearchNode)
                {
                    BSTNode temporaryParentNode = SearchNode.ParentNode;//save temporarily the value of its parent

                    //traverse up
                    while (SearchNode.Value < temporaryParentNode.Value && temporaryParentNode != Root)//traverse up until the temporaryParentNode is greater
                    {
                        temporaryParentNode = temporaryParentNode.ParentNode;
                        Predecessor = temporaryParentNode;

                    }


                    if (temporaryParentNode == Root && SearchNode.Value < temporaryParentNode.Value)//if the node is the root, meaning no the node is the getMinimum
                    {
                        Predecessor = null;
                    }

                }

            }

            return Predecessor;
        }


        //----------------PRINT Value IN TO THE BST IN ASCENDING ORDER------------------------------
        public void PrintInOrderRC_(BinarySearchTree mytree)//print the tree elements in ascending order using recursive call
        {
            printData = "";//clear the values inside

            if (Root == null)//if there is no ROOT, meaning tree is empty
            {
                isEmpty();


                return;
            }

            PrintInOrderRC(Root);//call the PrintInOrderRC subroutin in my MTMethods class
                                      //I separate the subroutine because I need to pass the Root first. 
            MessageBox.Show(printData);//if the the leftcnode is null then print the curent node POP the top value from the stack and print it

        }

        //-------------this is the callee. Caller PrintInOrderRC_ call this subroutine
        public void PrintInOrderRC(BSTNode root)//use recursive call
        {

            //this is the terminating condition of the recursion
            if (root == null)// once the node is null, meaning it is the last node in the traversed tree
            {
                return;
            }

            PrintInOrderRC(root.LeftNode);//push the values in the leftsubtree to the stack

            printData = printData +  root.Value.ToString() +"," ;//save the values here that are poppep-up

            PrintInOrderRC(root.RightNode);//push the values in the rightsubtree to the stack
           
        }

        // for the display only. to call everytime the root is empty
        public void isEmpty()
        {
                MessageBox.Show("Empty tree");
                return;
            
        }

        // for the display only. to call for the displate of the data that is being returned
        public void DisPlayVal(BSTNode ValueNode, string type)
        {

            MessageBox.Show(type +": " + ValueNode.Value.ToString());
        }
    }
}
